using AutoMapper;
using Blog.Data.Context;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstract;
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
		private readonly IMapper mapper;
		private readonly RoleManager<AppRole> roleManager;
		private readonly IValidator<AppUser> validator;
		private readonly IToastNotification toast;
		private readonly IUserService userService;
		public UserController( IMapper mapper, RoleManager<AppRole> roleManager, IValidator<AppUser> validator, IToastNotification toast,   IUserService userService = null)
		{
			this.mapper = mapper;
			this.roleManager = roleManager;
			this.validator = validator;
			this.toast = toast;		
			this.userService = userService;
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		public async Task<IActionResult> Index()
		{
			var result = await userService.GetAllUsersWithRoleAsync();
			return View(result);
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

			var map = mapper.Map<AppUser>(userAddDto);
			var roles = await roleManager.Roles.ToListAsync();
			var validate = await validator.ValidateAsync(map);
			if (validate.IsValid)
			{

				var result = await userService.CreateUserAsync(userAddDto);
				if (result.Succeeded)
				{
					toast.AddSuccessToastMessage(Message.User.Add(map.UserName));
					return RedirectToAction("Index");
				}
				else
				{
					result.AddToModelIdentityState(this.ModelState);
					validate.AddToModelState(this.ModelState);

				}
			}
			return View(new UserAddDto { Roles = roles });
		}
	
		[HttpGet]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Update(Guid userId)
		{
			var user = await userService.GetAppUserByIdAsync(userId);
			var roles = await userService.GetAllRolesAsync();
			var map = mapper.Map<UserUpdateDto>(user);
			map.Roles = roles;
			return View(map);
		}
		[HttpPost]
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
		{
			var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);
			if (user != null)
			{
				var roles = await userService.GetAllRolesAsync();				
					var map = mapper.Map(userUpdateDto, user);
					var validate = await validator.ValidateAsync(map);
					if (validate.IsValid)
					{
						user.UserName = userUpdateDto.Email;
						user.SecurityStamp = Guid.NewGuid().ToString();
						var result = await userService.UpdateUserAsync(userUpdateDto);
						if (result.Succeeded)
						{
							
							toast.AddSuccessToastMessage(Message.User.Update(user.UserName));
							return RedirectToAction("Index");

						}
						else
						{
							result.AddToModelIdentityState(this.ModelState);
							return View(new UserUpdateDto { Roles = roles });
						}
					}
				}
			return NotFound();
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}")]
		public async Task<IActionResult> Delete(Guid userId)
		{
			var result = await userService.DeleteUserAsync(userId) ;
			if (result.deleteResult.Succeeded)
			{
				toast.AddSuccessToastMessage(Message.User.Delete(result.email));
				return RedirectToAction("Index");

			}
			foreach (var error in result.deleteResult.Errors)
			{
				ModelState.AddModelError("", error.Description);

			}
			return NotFound();
		}
		[HttpGet]
		public async Task<IActionResult> Profile()
		{
			var profile=await userService.GetUserProfileAsync();
			return View(profile);

		}
		[HttpPost]
		public async Task<IActionResult> Profile(UserProfileDto profile)
		{
			
				var result=await userService.ProfileUpdateAsync(profile);
				if (result)
				{
					toast.AddSuccessToastMessage("Profile updated successfully");
					return RedirectToAction("Index");
				}
				else
				{
					var userprofile = await userService.GetUserProfileAsync();
					toast.AddErrorToastMessage("Something went wrong");
					return View(userprofile);
				}
			
		}
	}
}