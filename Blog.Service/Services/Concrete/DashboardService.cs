using Blog.Data.UnitOfWorks;
using Blog.Entity.Entities;
using Blog.Service.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Concrete
{
	public class DashboardService:IDashboardService
	{
		private readonly IUnitOfWork _unitOfWork;

		public DashboardService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public async Task<List<int>> GetYearlyArticlesAsync()
		{
			var startedDate= DateTime.Now.Date;
			startedDate = new DateTime(startedDate.Year, 1, 1);
			var articles = await _unitOfWork.GetRepository<Article>().GetAllAsync(x=>!x.IsDeleted);
			List<int> datas = new();
			for(int i = 1; i <= 12; i++)
			{
				var startdate=new DateTime(startedDate.Year,i, 1);
				var enddate = startdate.AddMonths(1);
				int data=articles.Where(a=>a.CreatedDate>=startedDate && a.CreatedDate<=enddate).Count();	
				datas.Add(data);
			}

			return datas;
		}
		public async Task<int> GetTotalArticleCount()
		{
			var count = await _unitOfWork.GetRepository<Article>().CountAsync();
			
			return count;
		}
		public async Task<int> GetTotalCategoryCount()
		{
			var count=await _unitOfWork.GetRepository<Category>().CountAsync();	
			return count;
		}
	}
}
