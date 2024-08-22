using AutoMapper;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Blog.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace Blog.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		ICategoryService _categoryService;
		private readonly IMapper mapper;
		private readonly IValidator<Category> validator;
		private readonly IToastNotification toast;

		public CategoryController(ICategoryService categoryService,IMapper mapper,IValidator<Category> validator,IToastNotification toast)
		{
			_categoryService = categoryService;
			this.mapper = mapper;
			this.validator = validator;
			this.toast = toast;
		}

		public async Task<IActionResult> Index()
		{
			var categories=await _categoryService.GetAllCategoriesAsync();
			return View(categories);
		}
		public async Task<IActionResult> DeletedCategories()
		{
			var categories = await _categoryService.GetAllDeletedCategoriesAsync();
			return View(categories);
		}
		[HttpGet]
		public IActionResult Add()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(CategoryAddDto categoryAddDto)
		{
			var map= mapper.Map<Category>(categoryAddDto);
			var result=await validator.ValidateAsync(map);
			if(result.IsValid)
			{
				await _categoryService.CreateCategory(categoryAddDto);
				toast.AddSuccessToastMessage(Message.Category.Add(categoryAddDto.Name));
				return RedirectToAction("Index");
			}
			else
			{
				result.AddToModelState(this.ModelState);
			return View();
			}
		}
		[HttpPost]
		public async Task<IActionResult> AddWithAjax([FromBody] CategoryAddDto categoryAddDto)
		{
			var map = mapper.Map<Category>(categoryAddDto);
			var result = await validator.ValidateAsync(map);
			if (result.IsValid)
			{
				await _categoryService.CreateCategory(categoryAddDto);
				toast.AddSuccessToastMessage(Message.Category.Add(categoryAddDto.Name));
				return Json(Message.Category.Add(categoryAddDto.Name));
			}
			else
			{
				toast.AddErrorToastMessage(result.Errors.FirstOrDefault().ErrorMessage);
				return Json(result.Errors.FirstOrDefault().ErrorMessage);
			}
		}
		[HttpGet]
		public async Task<IActionResult> Update(Guid categoryId)
		{
			var category=await _categoryService.GetCategoryByIdAsync(categoryId);
			var map=mapper.Map<CategoryUpdateDto>(category);
			return View(map);
		}
		[HttpPost]
		public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
		{
			var map=mapper.Map<Category>(categoryUpdateDto);
			var result = await validator.ValidateAsync(map);
			if(result.IsValid)
			{
				var name=await _categoryService.UpdateCategory(categoryUpdateDto);
				toast.AddSuccessToastMessage(Message.Category.Update(name));
				return RedirectToAction("Index");
			}
			result.AddToModelState(this.ModelState) ;
			return View(categoryUpdateDto);	
		}
		public async Task<IActionResult> Delete(Guid categoryId)
		{
			var name= await _categoryService.DeleteCategoryByIdAsync(categoryId);
			toast.AddSuccessToastMessage(Message.Category.Delete(name));
			return RedirectToAction("Index");

		}
		public async Task<IActionResult> UndoDelete(Guid categoryId)
		{
			var name = await _categoryService.UndoDeleteCategoryByIdAsync(categoryId);
			toast.AddSuccessToastMessage(Message.Category.UndoDelete(name));
			return RedirectToAction("Index");

		}
	}
}
