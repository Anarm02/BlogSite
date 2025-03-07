﻿using Blog.Entity.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstract
{
	public interface ICategoryService
	{
		Task<List<CategoryDto>> GetAllCategoriesAsync();
		Task<List<CategoryDto>> GetAllDeletedCategoriesAsync();
		Task<List<CategoryDto>> GetAllDeletedCategoriesTake24Async();
		Task CreateCategory(CategoryAddDto categoryAddDto);
		Task<string> UpdateCategory(CategoryUpdateDto categoryUpdateDto);
		Task<CategoryDto> GetCategoryByIdAsync(Guid id);
		Task<string> DeleteCategoryByIdAsync(Guid id);
		Task<string> UndoDeleteCategoryByIdAsync(Guid id);
	}
}
