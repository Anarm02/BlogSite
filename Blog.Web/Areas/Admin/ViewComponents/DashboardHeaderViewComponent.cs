using AutoMapper;
using Blog.Entity.DTOs.Users;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Areas.Admin.ViewComponents
{
	public class DashboardHeaderViewComponent:ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper mapper;

		public DashboardHeaderViewComponent(UserManager<AppUser> userManager, IMapper mapper)
		{
			_userManager = userManager;
			this.mapper = mapper;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var loggedUser = await _userManager.GetUserAsync(HttpContext.User);
			var map = mapper.Map<UserDto>(loggedUser);
			var role=string.Join("",await _userManager.GetRolesAsync(loggedUser));
			map.Role = role;
			return View(map);
		}
	}
}
