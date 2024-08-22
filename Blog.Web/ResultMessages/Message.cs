namespace Blog.Web.ResultMessages
{
	public static class Message
	{
		public static class Article {
			public static string Add(string title)
			{
				return $"The article named {title} has been added successfully";
			}
			public static string Update(string title)
			{
				return $"The article named {title} has been updated successfully";
			}
			public static string Delete(string title)
			{
				return $"The article named {title} has been deleted successfully";
			}
			public static string UndoDelete(string title)
			{
				return $"The article named {title} has been revoked successfully";
			}
		}
		public static class Category
		{
			public static string Add(string categoryname)
			{
				return $"The category named {categoryname} has been added successfully";
			}
			public static string Update(string categoryname)
			{
				return $"The category named {categoryname} has been updated successfully";
			}
			public static string Delete(string categoryname)
			{
				return $"The category named {categoryname} has been deleted successfully";
			}
			public static string UndoDelete(string categoryname)
			{
				return $"The category named {categoryname} has been revoked successfully";
			}
		}
		public static class User
		{
			public static string Add(string username)
			{
				return $"The user named {username} has been added successfully";
			}
			public static string Update(string username)
			{
				return $"The user named {username} has been updated successfully";
			}
			public static string Delete(string username)
			{
				return $"The user named {username} has been deleted successfully";
			}
		}

	}
}
