using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Helpers;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class UserService : IUserService
	{
		private readonly UserManager<AppUser> userManager;
		private readonly IImageHelper imageHelper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUnitOfWork unitOfWork;
		private readonly RoleManager<AppRole> roleManager;
		private readonly IMapper mapper;
		private readonly ClaimsPrincipal _user;
		private readonly SignInManager<AppUser> _signInManager;

		public UserService(UserManager<AppUser> userManager, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork, RoleManager<AppRole> roleManager, IMapper mapper, SignInManager<AppUser> signInManager)
		{
			this.userManager = userManager;
			this.imageHelper = imageHelper;
			this.httpContextAccessor = httpContextAccessor;
			this.unitOfWork = unitOfWork;
			this.roleManager = roleManager;
			this.mapper = mapper;
			_user = httpContextAccessor.HttpContext.User;
			_signInManager = signInManager;
		}

		public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
		{
			var map=mapper.Map<AppUser>(userAddDto);
			map.UserName = userAddDto.Email;
			var result =await userManager.CreateAsync(map,string.IsNullOrEmpty(userAddDto.Password) ? "": userAddDto.Password);
			if(result.Succeeded)
			{
				var findrole=await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
				await userManager.AddToRoleAsync(map, findrole.Name);
				return result;
			}
			else
				return result;
		}

		public async Task<(IdentityResult deleteResult, string? email)> DeleteUserAsync(Guid userId)
		{
			var user=await GetAppUserByIdAsync(userId);
			var result=await userManager.DeleteAsync(user);
			if (result.Succeeded)
				return (result, user.Email);
			else
				return (result, null);
		}

		public async Task<List<AppRole>> GetAllRolesAsync()
		{
			return await roleManager.Roles.ToListAsync();
		}

		public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
		{
			var users = await userManager.Users.ToListAsync();
			var map=mapper.Map<List<UserDto>>(users);
			foreach(var user in map)
			{
				var finduser = await userManager.FindByIdAsync(user.Id.ToString());
				var role = string.Join("", await userManager.GetRolesAsync(finduser));
				user.Role = role;
			}
			return map;
		}

		public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
		{
			return await userManager.FindByIdAsync(userId.ToString());	
		}

		public async Task<string> GetUserRole(AppUser user)
		{
			var roles = await userManager.GetRolesAsync(user);
			if (roles != null && roles.Count > 0)
			{
				return roles[0];
			}
			return null;
		}
		public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
		{
			var user = await GetAppUserByIdAsync(userUpdateDto.Id);
			if (user == null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "User not found." });
			}
			var role = await GetUserRole(user);
			var result = await userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				if (!string.IsNullOrWhiteSpace(role) && await userManager.IsInRoleAsync(user, role))
				{
					await userManager.RemoveFromRoleAsync(user, role);
					var findrole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
					if (findrole != null)
					{
						await userManager.AddToRoleAsync(user, findrole.Name);
					}
					else
					{
						return IdentityResult.Failed(new IdentityError { Description = "Role not found." });
					}
				}
				return result;
			}
			else
			{
				return result;
			}
		}
		public async Task<UserProfileDto> GetUserProfileAsync()
		{
			var userId = _user.GetLoggedInUserId();
			var getuserwithimage = await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
			var map=mapper.Map<UserProfileDto>(getuserwithimage);
			map.Image.FileName=getuserwithimage.Image.FileName;
			return map;
		}
		private async Task<Guid> UploadImageForUsers(UserProfileDto userProfileDto)
		{
			var userMail=_user.GetLoggedInMail();
			var imageToUpload =await imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, Entity.Enums.ImageType.User);
			Image image=new Image(imageToUpload.FullName,userProfileDto.Photo.ContentType,userMail);
			await unitOfWork.GetRepository<Image>().AddAsync(image);
			return image.Id;

		}
		public async Task<bool> ProfileUpdateAsync(UserProfileDto userProfileDto)
		{
			var userId = _user.GetLoggedInUserId();
			var user= await unitOfWork.GetRepository<AppUser>().GetAsync(x => x.Id == userId, x => x.Image);
			var isVerified=await userManager.CheckPasswordAsync(user,userProfileDto.CurrentPassword);
			if (isVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
			{
				var result = await userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
				if (result.Succeeded)
				{
					await userManager.UpdateSecurityStampAsync(user);
					await _signInManager.SignOutAsync();
					await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);
					user.FirstName = userProfileDto.FirstName;
					user.LastName = userProfileDto.LastName;
					user.PhoneNumber = userProfileDto.PhoneNumber;
					if (userProfileDto.Photo != null)
					{
						var imageid= await UploadImageForUsers(userProfileDto);
						if (imageid != Guid.Empty)
						{
							user.ImageId =imageid;
						}
						

					}
					await userManager.UpdateAsync(user);
					await unitOfWork.SaveAsynsc();
					return true;
				}
				else
					return false;
			}
			else if (isVerified )
			{
				await userManager.UpdateSecurityStampAsync(user);
				user.FirstName = userProfileDto.FirstName;
				user.LastName = userProfileDto.LastName;
				user.PhoneNumber = userProfileDto.PhoneNumber;
				if (userProfileDto.Photo != null)
				{
					var imageid = await UploadImageForUsers(userProfileDto);
					if (imageid != Guid.Empty)
					{
						user.ImageId = imageid;
					}


				}
				var id = user.ImageId;
				await userManager.UpdateAsync(user);
				await unitOfWork.SaveAsynsc();
				return true;
			}
			else
				return false;
		}

	}
}
