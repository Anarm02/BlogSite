using Blog.Entity.DTOs.Articles;
using Blog.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstract
{
    public interface IArticleService
    {
        Task<List<ArticleDto>> GetAllArticleAsync();
        Task<List<ArticleDto>> GetAllDeletedArticleAsync();
		Task<ArticleDto> GetArticleAsync(Guid articleId);
		Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task<string> UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
        Task<string> SafeDeleteArticleAsync(Guid articleId);
        Task<string> UndoDeleteArticleAsync(Guid articleId);
        Task<ArticleListDto> GetAllPagingAsync(Guid? categoryId, bool isAscending = false, int pageSize = 3, int currentPage = 1);
        Task<ArticleListDto> SearchAsync(string keyword, bool isAscending = false, int pageSize = 3, int currentPage = 1);
	}
}
