using AutoMapper;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Blog.Web.Consts;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ArticleController : Controller
	{
		private readonly IArticleService articleService;
		private readonly ICategoryService categoryService;
		private readonly IMapper mapper;
		private readonly IValidator<Article> validator;
		private readonly IToastNotification toast;

		public ArticleController(IArticleService articleService, 
			ICategoryService categoryService, 
			IMapper mapper,
			IValidator<Article> validator,
			IToastNotification toast
			)
		{
			this.articleService = articleService;
			this.categoryService = categoryService;
			this.mapper = mapper;
			this.validator = validator;
			this.toast = toast;
		}
		[Authorize(Roles =$"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}, {RoleConsts.User}")]
		public async Task<IActionResult> Index()
		{
			var articles =await articleService.GetAllArticleAsync();
			return View(articles);
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]

		public async Task<IActionResult> DeletedArticles()
		{
			var articles = await articleService.GetAllDeletedArticleAsync();
			return View(articles);
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var categories = await categoryService.GetAllCategoriesAsync();
			return View(new ArticleAddDto { Categories=categories});
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpPost]
		public async Task<IActionResult> Add(ArticleAddDto articleAddDto)
		{
			var map=mapper.Map<Article>(articleAddDto);
			var result=await validator.ValidateAsync(map);
			if (result.IsValid)
			{
				await articleService.CreateArticleAsync(articleAddDto);
				toast.AddSuccessToastMessage(Message.Article.Add(articleAddDto.Title));
				return RedirectToAction("Index", "Article", new { Area = "Admin" });
			}
			else
			{
				result.AddToModelState(this.ModelState);
				var categories = await categoryService.GetAllCategoriesAsync();
				return View(new ArticleAddDto { Categories = categories });
			}
			
			
		
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpGet]
		public async Task<IActionResult> Update(Guid articleId)
		{
			var article =await articleService.GetArticleAsync(articleId);
			var categories= await categoryService.GetAllCategoriesAsync();
			ArticleUpdateDto articleUpdateDto = mapper.Map<ArticleUpdateDto>(article);
			articleUpdateDto.Categories = categories;
			return View(articleUpdateDto);
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		[HttpPost]
		public async Task<IActionResult> Update(ArticleUpdateDto articleUpdateDto)
		{
			var map = mapper.Map<Article>(articleUpdateDto);
			var result = await validator.ValidateAsync(map);
			if (result.IsValid)
			{
			var title=await articleService.UpdateArticleAsync(articleUpdateDto);
				toast.AddSuccessToastMessage(Message.Article.Update(title));
				return RedirectToAction("Index", "Article", new { Area = "Admin" });

			}
			else
			{
				result.AddToModelState(this.ModelState);
				var categories = await categoryService.GetAllCategoriesAsync();

				articleUpdateDto.Categories = categories;
				return View(articleUpdateDto);
			}
		
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]

		public async Task<IActionResult> Delete(Guid articleId)
		{
			
			var title=await articleService.SafeDeleteArticleAsync(articleId);
			toast.AddSuccessToastMessage(Message.Article.Delete(title));
			return RedirectToAction("Index", "Article", new {Area="Admin"});
		}
		[Authorize(Roles = $"{RoleConsts.SuperAdmin}, {RoleConsts.Admin}")]
		public async Task<IActionResult> UndoDelete(Guid articleId)
		{

			var title = await articleService.UndoDeleteArticleAsync(articleId);
			toast.AddSuccessToastMessage(Message.Article.UndoDelete(title));
			return RedirectToAction("Index", "Article", new { Area = "Admin" });
		}
	}
}
