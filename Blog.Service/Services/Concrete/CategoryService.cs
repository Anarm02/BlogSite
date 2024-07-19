using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Categories;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IMapper mapper;
		private readonly IUnitOfWork unitOfWork;
        public CategoryService(IMapper mapper,IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
			this.mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
		{
			return mapper.Map<List<CategoryDto>>(await unitOfWork.GetRepository<Category>().GetAllAsync(c=>!c.IsDeleted));
		}
	}
}
