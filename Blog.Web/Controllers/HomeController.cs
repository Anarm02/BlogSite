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
        [HttpGet]
        public async Task<IActionResult> Index(Guid? categoryId, int currentPage=1, int pageSize=3, bool isAscending=false)
        {
            var articles=await articleService.GetAllPagingAsync(categoryId,isAscending,pageSize,currentPage);
            return View(articles);
        }
        [HttpGet]
        public async Task<IActionResult> Search(string keyword, int currentPage=1, int pageSize=3, bool isAscending = false)
        {
            var articles=await articleService.SearchAsync(keyword,isAscending,pageSize,currentPage);    
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
        public async Task<IActionResult> Details(Guid id)
        {
            var article=await articleService.GetArticleAsync(id);
            return View(article);
        }
    }
}
