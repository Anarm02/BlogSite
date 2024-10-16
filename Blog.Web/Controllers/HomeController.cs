using Blog.Service.Services.Abstract;
using Blog.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService articleService;
		private readonly IDashboardService dashboardService;

		public HomeController(ILogger<HomeController> logger,IArticleService articleService,IDashboardService dashboardService)
        {
            _logger = logger;
            this.articleService = articleService;
			this.dashboardService = dashboardService;
		}

        public async Task<IActionResult> Index()
        {
            var articles=await articleService.GetAllArticleAsync();
            return View(articles);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
