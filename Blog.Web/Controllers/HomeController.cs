using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
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
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IUnitOfWork unitOfWork;

		public HomeController(ILogger<HomeController> logger,IArticleService articleService,IDashboardService dashboardService,IHttpContextAccessor httpContextAccessor,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            this.articleService = articleService;
			this.dashboardService = dashboardService;
			this.httpContextAccessor = httpContextAccessor;
			this.unitOfWork = unitOfWork;
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
            string ipAddress=httpContextAccessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            var articleVisitors = await unitOfWork.GetRepository<ArticleVisitor>().GetAllAsync(null, x => x.Visitor, x => x.Article);
            var article = await unitOfWork.GetRepository<Article>().GetAsync(x=>x.Id==id);
            var visitor=await unitOfWork.GetRepository<Visitor>().GetAsync(x=>x.IpAddress==ipAddress);
            ArticleVisitor articleVisitor = new(article.Id, visitor.Id);
            var result=await articleService.GetArticleAsync(id);
            if (articleVisitors.Any(x => x.ArticleId == article.Id && x.VisitorId == visitor.Id))
                return View(result);
            else
            {
                await unitOfWork.GetRepository<ArticleVisitor>().AddAsync(articleVisitor);
                article.ViewCount += 1;
                await unitOfWork.GetRepository<Article>().UpdateAsync(article);
                await unitOfWork.SaveAsynsc();
            }
            return View(result);
        }
    }
}
