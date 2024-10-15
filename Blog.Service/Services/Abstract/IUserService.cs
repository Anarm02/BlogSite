using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstract
{
	public interface IUserService
	{
		Task<List<UserDto>> GetAllUsersWithRoleAsync();
		Task<List<AppRole>> GetAllRolesAsync();
		Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto);
		Task<AppUser> GetAppUserByIdAsync(Guid userId);
		Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto);
		Task<string> GetUserRole(AppUser user);
		Task<(IdentityResult deleteResult, string? email)> DeleteUserAsync(Guid userId);
		Task<UserProfileDto> GetUserProfileAsync();
		Task<bool> ProfileUpdateAsync(UserProfileDto userProfileDto);
	}
}
