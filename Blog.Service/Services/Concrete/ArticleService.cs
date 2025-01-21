using AutoMapper;
using Blog.Data.UnitOfWorks;
using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using Blog.Entity.Enums;
using Blog.Service.Extensions;
using Blog.Service.Helpers;
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
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
		private readonly IHttpContextAccessor httpContextAccessor;
		private readonly IImageHelper imageHelper;
		ClaimsPrincipal _user;

		public ArticleService(IUnitOfWork unitOfWork,IMapper mapper,IHttpContextAccessor httpContextAccessor,IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
			this.httpContextAccessor = httpContextAccessor;
			this.imageHelper = imageHelper;
			_user = httpContextAccessor.HttpContext.User;
		}

		public async Task CreateArticleAsync(ArticleAddDto articleAddDto)
		{
            var userId = _user.GetLoggedInUserId();
            var email=_user.GetLoggedInMail();
            var image=await imageHelper.Upload(articleAddDto.Title,articleAddDto.Photo,ImageType.Post);
            Image image1 = new(image.FullName,articleAddDto.Photo.ContentType,email,image.FullPath);
            await _unitOfWork.GetRepository<Image>().AddAsync(image1);
			var article = new Article(articleAddDto.Title, articleAddDto.Content, userId, articleAddDto.CategoryId, image1.Id,email);
            await _unitOfWork.GetRepository<Article>().AddAsync(article);
            await _unitOfWork.SaveAsynsc();
		}

		public async Task<List<ArticleDto>> GetAllArticleAsync()
        {
            
            return  _mapper.Map<List<ArticleDto>>(await _unitOfWork.GetRepository<Article>().GetAllAsync(a=>!a.IsDeleted,a=>a.Category,a=>a.Image));
        }
        public async Task<ArticleListDto> GetAllPagingAsync(Guid? categoryId,bool isAscending=false,int pageSize=3,int currentPage = 1)
        {
            pageSize=pageSize>20 ? 20 : pageSize;
            var articles = categoryId == null ? await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted, a => a.Category, a => a.Image,a=>a.User)
                : await _unitOfWork.GetRepository<Article>().GetAllAsync(a => !a.IsDeleted && a.CategoryId == categoryId, a => a.Category, a => a.Image,a=>a.User);
            var sortedArticles=isAscending ? articles.OrderBy(a=>a.CreatedDate).Skip((currentPage-1)*pageSize).Take(pageSize).ToList() :
                articles.OrderByDescending(a=>a.CreatedDate).Skip((currentPage-1)*pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CategoryId = categoryId == null ? null : categoryId.Value,
                CurrentPage = currentPage,
                PageSize = pageSize,
                IsAscending = isAscending,
                TotalCount = articles.Count
            };
                
        }

		public async Task<List<ArticleDto>> GetAllDeletedArticleAsync()
		{
			return _mapper.Map<List<ArticleDto>>(await _unitOfWork.GetRepository<Article>().GetAllAsync(a => a.IsDeleted, a => a.Category, a => a.Image));

		}

		public async Task<ArticleDto> GetArticleAsync(Guid articleId)
		{
			var article=await _unitOfWork.GetRepository<Article>().GetAsync(a=>a.Id==articleId && a.IsDeleted==false,a=>a.Category,a=>a.Image,a=>a.User);
            var map=_mapper.Map<ArticleDto>(article);
            return map;
		}

		public async Task<string> SafeDeleteArticleAsync(Guid articleId)
		{
			var email = _user.GetLoggedInMail();
			var article =await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
            article.IsDeleted = true;
            article.DeletedDate = DateTime.Now; 
            article.DeletedBy=email;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsynsc();
            return article.Title;
		}

		public async Task<string> UndoDeleteArticleAsync(Guid articleId)
		{
			var article = await _unitOfWork.GetRepository<Article>().GetByGuidAsync(articleId);
			article.IsDeleted = false;
			article.DeletedDate = null;
			article.DeletedBy = null;
			await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
			await _unitOfWork.SaveAsynsc();
			return article.Title;
		}

		public async Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto)
		{
			var email = _user.GetLoggedInMail();
			var article = await _unitOfWork.GetRepository<Article>().GetAsync(a => a.Id==articleUpdateDto.Id && a.IsDeleted == false, a => a.Category,a=>a.Image);
            if(articleUpdateDto.Photo != null)
            {
                if (article.Image != null) {
					imageHelper.Delete(article.Image.FileName);
				}
                else
                {
                    throw new Exception("Article image is null");
                }
                
                var imageUpload = await imageHelper.Upload(articleUpdateDto.Title, articleUpdateDto.Photo, ImageType.Post);
                Image image = new(imageUpload.FullName, articleUpdateDto.Photo.ContentType, email,imageUpload.FullPath);
                await _unitOfWork.GetRepository<Image>().AddAsync(image);
                article.ImageId= image.Id;
            }
            string articletitlebefore = article.Title;
			
           article.ModifiedDate = DateTime.Now;
            article.Title = articleUpdateDto.Title;
            article.Content= articleUpdateDto.Content;
            article.CategoryId=articleUpdateDto.CategoryId;
            article.ModifiedBy = email;
            await _unitOfWork.GetRepository<Article>().UpdateAsync(article);
            await _unitOfWork.SaveAsynsc();
            return articletitlebefore;
		}

		public async Task<ArticleListDto> SearchAsync(string keyword, bool isAscending = false, int pageSize = 3, int currentPage = 1)
		{
            pageSize = pageSize > 20 ? 20 : pageSize;
            var articles=await _unitOfWork.GetRepository<Article>().GetAllAsync(a=>!a.IsDeleted
            && (a.Content.Contains(keyword) || a.Category.Name.Contains(keyword) || a.Title.Contains(keyword)), a=>a.Image,a=>a.Category,a=>a.User);
            var sortedArticles=isAscending ? articles.OrderBy(a=>a.CreatedDate).Skip((currentPage-1)* pageSize).Take(pageSize).ToList()
				: articles.OrderByDescending(a => a.CreatedDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            return new ArticleListDto
            {
                Articles = sortedArticles,
                CurrentPage = currentPage,
                IsAscending = isAscending,
                PageSize = pageSize,
                TotalCount = articles.Count()
            };
		}
	}
}
