using AutoMapper;
using Blog.Data.Context;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers;
using Blog.Web.Consts;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IMapper mapper;
		private readonly RoleManager<AppRole> roleManager;
		private readonly IValidator<AppUser> validator;
		private readonly IToastNotification toast;
		AppDbContext _context;
		private readonly SignInManager<AppUser> _signInManager;
		private readonly IImageHelper imageHelper;
		private readonly IUnitOfWork unitOfWork;
		public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IToastNotification toast, AppDbContext context = null, SignInManager<AppUser> signInManager = null, IImageHelper imageHelper = null, IUnitOfWork unitOfWork = null)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.roleManager = roleManager;
			this.validator = validator;
			this.toast = toast;
			_context = context;
			_signInManager = signInManager;
			this.imageHelper = imageHelper;
			this.unitOfWork = unitOfWork;
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		public async Task<IActionResult> Index()
		{
			var users = await userManager.Users.ToListAsync();
			var map = mapper.Map<List<UserDto>>(users);
			foreach (var user in map)
			{
				var finduser = await userManager.FindByIdAsync(user.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(finduser));
				user.Role = role;
			}

			return View(map);
		}
		[HttpGet]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Add()
		{
			var roles = await roleManager.Roles.ToListAsync();
			return View(new UserAddDto { Roles = roles });
		}
		[HttpPost]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			using (var transaction = await _context.Database.BeginTransactionAsync())
			{
				var map = mapper.Map<AppUser>(userAddDto);
				var roles = await roleManager.Roles.ToListAsync();
				var validate = await validator.ValidateAsync(map);
				map.UserName = userAddDto.Email;
				var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
				if (result.Succeeded)
				{
					var role = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
					if (role != null)
					{
						await userManager.AddToRoleAsync(map, role.Name);
						toast.AddSuccessToastMessage(Message.User.Add(map.UserName));
						await transaction.CommitAsync(); // İşlem başarılı, değişiklikleri kaydet
						return RedirectToAction("Index");
					}
					else
					{
						ModelState.AddModelError("", "Selected role does not exist.");
					}
				}
				else
				{
					result.AddToModelIdentityState(this.ModelState);
					validate.AddToModelState(this.ModelState);

				}

				await transaction.RollbackAsync(); // Hata durumunda işlemi geri al
				return View(new UserAddDto { Roles = roles });
			}
		}
		[HttpGet]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Update(Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());
			var roles = await roleManager.Roles.ToListAsync();
			var map = mapper.Map<UserUpdateDto>(user);
			map.Roles = roles;
			return View(map);
		}
		[HttpPost]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
			if (user != null)
			{
				var roles = await roleManager.Roles.ToListAsync();
				var userRole = string.Join("", await userManager.GetRolesAsync(user));

				using (var transaction = await _context.Database.BeginTransactionAsync())
				{

					var map = mapper.Map(userUpdateDto, user);
					var validate = await validator.ValidateAsync(map);
					if (validate.IsValid)
					{
						user.UserName = userUpdateDto.Email;
						user.SecurityStamp = Guid.NewGuid().ToString();
						var result = await userManager.UpdateAsync(map);
						if (result.Succeeded)
						{
							await userManager.RemoveFromRoleAsync(user, userRole);
							var role = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
							await userManager.AddToRoleAsync(user, role.Name);
							toast.AddSuccessToastMessage(Message.User.Update(user.UserName));
							await transaction.CommitAsync(); // İşlem başarılı, değişiklikleri kaydet
							return RedirectToAction("Index");

						}
						else
						{


							result.AddToModelIdentityState(this.ModelState);
							return View(new UserUpdateDto { Roles = roles });

						}
					}
					else
					{
						validate.AddToModelState(this.ModelState);
						return View(new UserUpdateDto { Roles = roles });

					}
				}
			}
			return NotFound();
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Delete(Guid userId)
		{
			var user = await userManager.FindByIdAsync(userId.ToString());
			var result = await userManager.DeleteAsync(user);
			if (result.Succeeded)
			{
				toast.AddSuccessToastMessage(Message.User.Delete(user.UserName));
				return RedirectToAction("Index");

			}
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError("", error.Description);

			}
			return NotFound();
		}
		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var user = await userManager.GetUserAsync(HttpContext.User);
			var getimage=await unitOfWork.GetRepository<AppUser>().GetAsync(x=>x.Id==user.Id,x=>x.Image);
			var map=mapper.Map<UserProfileDto>(user);
			map.Image.FileName=getimage.Image.FileName;
			return View(map);

		}
		[HttpPost]
		public async Task<IActionResult> Profile(UserProfileDto profile)
		{
			var user=await userManager.GetUserAsync(HttpContext.User);
			if (ModelState.IsValid)
			{
				var userVerified=await userManager.CheckPasswordAsync(user,profile.CurrentPassword);
				if (userVerified && profile.NewPassword != null && profile.Photo!=null)
				{
					var result=await userManager.ChangePasswordAsync(user,profile.CurrentPassword,profile.NewPassword);
					if (result.Succeeded)
					{
						await userManager.UpdateSecurityStampAsync(user);
						await _signInManager.SignOutAsync();
						await _signInManager.PasswordSignInAsync(user, profile.NewPassword, true, false);
						user.FirstName = profile.FirstName;
						user.LastName = profile.LastName;
						user.PhoneNumber = profile.PhoneNumber;
						var image=await imageHelper.Upload($"{profile.FirstName}{profile.LastName}",profile.Photo,ImageType.User);
						Image image1 = new Image(image.FullName, profile.Photo.ContentType, profile.Email);
						await unitOfWork.GetRepository<Image>().AddAsync(image1);
						user.ImageId = image1.Id;
						await userManager.UpdateAsync(user);
						toast.AddSuccessToastMessage("Your password and profile updated successfully");
						return View();
					}
					else
						toast.AddErrorToastMessage("Something went wrong"); return View();
				}
				else if (userVerified && profile.Photo!=null)
				{
					await userManager.UpdateSecurityStampAsync(user);
					user.FirstName = profile.FirstName;
					user.LastName = profile.LastName;
					user.PhoneNumber = profile.PhoneNumber;
					var image = await imageHelper.Upload($"{profile.FirstName}{profile.LastName}", profile.Photo, ImageType.User);
					Image image1 = new Image(image.FullName, profile.Photo.ContentType, profile.Email);
					await unitOfWork.GetRepository<Image>().AddAsync(image1);
					user.ImageId = image1.Id;
					await userManager.UpdateAsync(user);
					toast.AddSuccessToastMessage("Your profile updated successfully");
					return View();
				}
				else
					toast.AddErrorToastMessage("Something went wrong"); return View();
			}
				return View();
		}
	}
}