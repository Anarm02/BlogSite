using Blog.Data.Context;
using Blog.Data.Extensions;
using Blog.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.Load(builder.Configuration);
            builder.Services.LoadService();
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            var app = builder.Build();
           
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name:"Admin",
                    areaName:"Admin",
                    pattern:"Admin/{controller=Home}/{action=index}/{id?}"
                    );
                endpoints.MapDefaultControllerRoute();
            });

            app.Run();
        }
    }
}