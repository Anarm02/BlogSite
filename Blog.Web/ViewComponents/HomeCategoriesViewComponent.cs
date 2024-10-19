using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.ViewComponents
{
	public class HomeCategoriesViewComponent:ViewComponent
	{
		private readonly ICategoryService _categoryService;

		public HomeCategoriesViewComponent(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var categories= await _categoryService.GetAllDeletedCategoriesTake24Async();
			return View(categories);
		}
	}
}
