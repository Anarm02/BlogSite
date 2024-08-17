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
		}

	}
}
