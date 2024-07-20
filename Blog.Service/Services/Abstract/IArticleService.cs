﻿using Blog.Entity.DTOs.Articles;
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
        Task<ArticleDto> GetArticleAsync(Guid articleId);
		Task CreateArticleAsync(ArticleAddDto articleAddDto);
        Task UpdateArticleAsync(ArticleUpdateDto articleUpdateDto);
    }
}
