using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
            var userId = Guid.Parse("60F812E7-9374-4623-873B-C28D9F6437E4");

		   await _unitOfWork.GetRepository<Article>().AddAsync(new()
            {
                CategoryId = articleAddDto.CategoryId,
                Title = articleAddDto.Title,
                Content = articleAddDto.Content,
                UserId= userId, 

            });
            await _unitOfWork.SaveAsynsc();
		}

		public async Task<List<ArticleDto>> GetAllArticleAsync()
        {
            
            return  _mapper.Map<List<ArticleDto>>(await _unitOfWork.GetRepository<Article>().GetAllAsync(a=>!a.IsDeleted,a=>a.Category));
        }
    }
}
