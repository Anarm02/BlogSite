using Blog.Entity.DTOs.Images;
using Blog.Entity.Enums;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Helpers
{
	public class ImageHelper : IImageHelper
	{
		private readonly IWebHostEnvironment env;
		private readonly string wwwroot;
		private const string imageFolder = "images";
		private const string articleImageFolder = "article-images";
		private const string userImageFolder = "user-images";
		public ImageHelper(IWebHostEnvironment env)
        {
			this.env = env;
			wwwroot = env.WebRootPath;
		}
		private string ReplaceInvalidChars(string fileName)
		{
			return fileName.Replace("İ", "I")
				 .Replace("ı", "i")
				 .Replace("Ğ", "G")
				 .Replace("ğ", "g")
				 .Replace("Ü", "U")
				 .Replace("ü", "u")
				 .Replace("ş", "s")
				 .Replace("Ş", "S")
				 .Replace("Ö", "O")
				 .Replace("ö", "o")
				 .Replace("Ç", "C")
				 .Replace("ç", "c")
				 .Replace("é", "")
				 .Replace("!", "")
				 .Replace("'", "")
				 .Replace("^", "")
				 .Replace("+", "")
				 .Replace("%", "")
				 .Replace("/", "")
				 .Replace("(", "")
				 .Replace(")", "")
				 .Replace("=", "")
				 .Replace("?", "")
				 .Replace("_", "")
				 .Replace("*", "")
				 .Replace("æ", "")
				 .Replace("ß", "")
				 .Replace("@", "")
				 .Replace("€", "")
				 .Replace("<", "")
				 .Replace(">", "")
				 .Replace("#", "")
				 .Replace("$", "")
				 .Replace("½", "")
				 .Replace("{", "")
				 .Replace("[", "")
				 .Replace("]", "")
				 .Replace("}", "")
				 .Replace(@"\", "")
				 .Replace("|", "")
				 .Replace("~", "")
				 .Replace("¨", "")
				 .Replace(",", "")
				 .Replace(";", "")
				 .Replace("`", "")
				 .Replace(".", "")
				 .Replace(":", "")
				 .Replace(" ", "");
		}

		public void Delete(string name)
		{
			var fileToDelete = Path.Combine($"{wwwroot}/{imageFolder}/{name}");
			if (File.Exists(fileToDelete) ) 
				File.Delete(fileToDelete);
		}

		public async Task<ImgUploadDto> Upload(string name, IFormFile imageFile,ImageType imageType ,string foldername = null)
		{
			foldername??= imageType==ImageType.User? userImageFolder:articleImageFolder;
			if (!Directory.Exists($"{wwwroot}/{imageFolder}/{foldername}"))
				Directory.CreateDirectory($"{wwwroot}/{imageFolder}/{foldername}");
			string oldname=Path.GetFileNameWithoutExtension(imageFile.FileName);
			string ext = Path.GetExtension(imageFile.FileName);
			name=ReplaceInvalidChars(name);
			DateTime dateTime = DateTime.Now;
			string newname = $"{name}_{dateTime.Millisecond}{ext}";
			var path = Path.Combine($"{wwwroot}/{imageFolder}/{foldername}", newname);
			await using FileStream stream=new FileStream(path,FileMode.Create,FileAccess.Write,FileShare.None,1024*1024,useAsync:false);
			await imageFile.CopyToAsync(stream);
			await stream.FlushAsync();
			return new ImgUploadDto { FullName=$"{foldername}/{newname}",FullPath=path };
		}
	}
}
