using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services.Abstract
{
	public interface IDashboardService
	{
		Task<List<int>> GetYearlyArticlesAsync();
		Task<int> GetTotalArticleCount();
		Task<int> GetTotalCategoryCount();
	}
}
