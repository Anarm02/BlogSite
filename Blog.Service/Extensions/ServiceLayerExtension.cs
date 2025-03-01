﻿using Blog.Service.Helpers;
using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using Blog.Service.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
	public static class ServiceLayerExtension
	{
		public static IServiceCollection LoadService(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddScoped<IArticleService, ArticleService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IImageHelper, ImageHelper>();
			services.AddScoped<IDashboardService, DashboardService>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddValidatorsFromAssemblyContaining<ArticleValidator>();
			services.AddAutoMapper(assembly);
			return services;
		}
	}
}
