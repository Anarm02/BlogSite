using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Blog.Web.Filters.ArticleVisitors
{
	public class ArticleVisitorFilter : IAsyncActionFilter
	{
		private readonly IUnitOfWork unitOfWork;

		public ArticleVisitorFilter(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
		{
		List<Visitor> visitors=await unitOfWork.GetRepository<Visitor>().GetAllAsync();
			string getIp=context.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
			string userAgent = context.HttpContext.Request.Headers["User-Agent"];
			Visitor visitor=new(getIp, userAgent);
			if (visitors.Any(x => x.IpAddress == getIp)) 
				 await next();
			else
			{
				await unitOfWork.GetRepository<Visitor>().AddAsync(visitor);
				await unitOfWork.SaveAsynsc();
			}
			await next();	
		}
	}
}
