using AutoMapper;
using Blog.Data.Context;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Web.ResultMessages;
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
		private readonly IToastNotification toast;
		AppDbContext _context;

		public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toast, AppDbContext context = null)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.roleManager = roleManager;
			this.toast = toast;
			_context = context;
		}
		public async Task<IActionResult> Index()
		{
			var users=await userManager.Users.ToListAsync();
			var map = mapper.Map<List<UserDto>>(users);
			foreach (var user in map)
			{
				var finduser=await userManager.FindByIdAsync(user.Id.ToString());
				var role=string.Join("",await userManager.GetRolesAsync(finduser));
				user.Role = role;
			}

			return View(map);
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var roles=await roleManager.Roles.ToListAsync();
			return View(new UserAddDto { Roles=roles});
		}
		[HttpPost]
		public async Task<IActionResult> Add(UserAddDto userAddDto)
		{
			using (var transaction = await _context.Database.BeginTransactionAsync())
			{
				var map = mapper.Map<AppUser>(userAddDto);
				var roles = await roleManager.Roles.ToListAsync();

				map.UserName = userAddDto.Email;
				var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "": userAddDto.Password);
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
					foreach (var error in result.Errors)
					{
						ModelState.AddModelError("", error.Description);
					}
				}

				await transaction.RollbackAsync(); // Hata durumunda işlemi geri al
				return View(new UserAddDto { Roles = roles });
			}
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid userId)
		{
			var user=await userManager.FindByIdAsync(userId.ToString());
			var roles=await roleManager.Roles.ToListAsync();
			var map=mapper.Map<UserUpdateDto>(user);
			map.Roles= roles;
			return View(map);
		}
		[HttpPost]	
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var user=await userManager.FindByIdAsync(userUpdateDto.Id.ToString());
			if (user != null)
			{
				var roles = await roleManager.Roles.ToListAsync();
				var userRole = string.Join("",await userManager.GetRolesAsync(user));
				using (var transaction = await _context.Database.BeginTransactionAsync())
				{
				
					mapper.Map(userUpdateDto, user);
					user.UserName = userUpdateDto.Email;
					user.SecurityStamp=Guid.NewGuid().ToString();
					var result = await userManager.UpdateAsync(user);
					if(result.Succeeded)
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
						foreach (var error in result.Errors)
						{
							ModelState.AddModelError("", error.Description);
							return View(new UserUpdateDto { Roles = roles });
						}
					}

				await transaction.RollbackAsync(); // Hata durumunda işlemi geri al
				return View(new UserUpdateDto { Roles = roles });
				}
			}
			return NotFound();
		}
		public async Task<IActionResult> Delete(Guid userId)
		{
			var user=await userManager.FindByIdAsync(userId.ToString());
			var result= await userManager.DeleteAsync(user);
			if(result.Succeeded)
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

	}
}
