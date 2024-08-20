using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Extensions;
using Blog.Service.Services.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IMapper mapper;
		private readonly IUnitOfWork unitOfWork;
		private readonly IHttpContextAccessor httpContextAccessor;
		ClaimsPrincipal _user;

		public CategoryService(IMapper mapper,IUnitOfWork unitOfWork,IHttpContextAccessor httpContextAccessor)
        {
            this.unitOfWork = unitOfWork;
			this.httpContextAccessor = httpContextAccessor;
			this.mapper = mapper;
			_user = httpContextAccessor.HttpContext.User;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
		{
			return mapper.Map<List<CategoryDto>>(await unitOfWork.GetRepository<Category>().GetAllAsync(c=>!c.IsDeleted));
		}
		public async Task CreateCategory(CategoryAddDto categoryAddDto)
		{
			var email=_user.GetLoggedInMail();
			Category category= new Category(categoryAddDto.Name,email);
			await unitOfWork.GetRepository<Category>().AddAsync(category);
			await unitOfWork.SaveAsynsc();
		}

		public async Task<string> UpdateCategory(CategoryUpdateDto categoryUpdateDto)
		{
			var email = _user.GetLoggedInMail();
			var category=await unitOfWork.GetRepository<Category>().GetByGuidAsync(categoryUpdateDto.Id);
			var nameBefore=category.Name;
			category.Name= categoryUpdateDto.Name;
			category.ModifiedBy = email;
			category.ModifiedDate = DateTime.Now;
			await unitOfWork.GetRepository<Category>().UpdateAsync(category);
			await unitOfWork.SaveAsynsc();
			return nameBefore;
		}

		public async Task<CategoryDto> GetCategoryByIdAsync(Guid id)
		{
			var category=await unitOfWork.GetRepository<Category>().GetAsync(c=>c.Id==id && c.IsDeleted==false);
			var map = mapper.Map<CategoryDto>(category);
			return map;
		}

		public async Task<string> DeleteCategoryByIdAsync(Guid id)
		{
			var email= _user.GetLoggedInMail();	
			var category=await unitOfWork.GetRepository<Category>().GetByGuidAsync(id);
			category.IsDeleted=true;
			category.DeletedDate = DateTime.Now;
			category.DeletedBy = email;
			await unitOfWork.GetRepository<Category>().UpdateAsync(category);
			await unitOfWork.SaveAsynsc();
			return category.Name;

		}
	}
}
