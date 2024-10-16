using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
		private readonly IDashboardService dashboardService;
		public HomeController(IArticleService articleService, UserManager<AppUser> userManager, IDashboardService dashboardService)
		{
			_articleService = articleService;
			_userManager = userManager;
			this.dashboardService = dashboardService;
		}
		public async Task<IActionResult> Index()
        {
            var articles=await _articleService.GetAllArticleAsync();
            var loggeduser=await _userManager.GetUserAsync(HttpContext.User);
            return View(articles);
        }
		[HttpGet]
		public async Task<IActionResult> YearlyArticleCounts()
		{
			var count = await dashboardService.GetYearlyArticlesAsync();
			return Json(JsonConvert.SerializeObject(count));
		}
		[HttpGet]
		public async Task<IActionResult> TotalArticleCount()
		{
			var count = await dashboardService.GetTotalArticleCount();
			return Json(count);
		}
		[HttpGet]
		public async Task<IActionResult> TotalCategoryCount()
		{
			var count = await dashboardService.GetTotalCategoryCount();
			return Json(count);
		}
	}
}
