using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
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
            var assembly=Assembly.GetExecutingAssembly();
            services.AddScoped<IArticleService,ArticleService>().Reverse();
            services.AddScoped<ICategoryService,CategoryService>().Reverse();

            services.AddAutoMapper(assembly);
            return services;
        }
    }
}
