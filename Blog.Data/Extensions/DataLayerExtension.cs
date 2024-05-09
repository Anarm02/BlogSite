using Blog.Data.Repositories.Abstract;
using Blog.Data.Repositories.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Extensions
{
    public static class DataLayerExtension
    {
        public static IServiceCollection Load(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
            return services;
        }
    }
}
