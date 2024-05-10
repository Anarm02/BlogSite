using Blog.Service.Services.Abstract;
using Blog.Service.Services.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Extensions
{
    public static class ServiceLayerExtension
    {
        public static IServiceCollection LoadService(this IServiceCollection services)
        {
            services.AddScoped<IArticleService,ArticleService>().Reverse();
            return services;
        }
    }
}
