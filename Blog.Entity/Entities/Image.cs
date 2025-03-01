﻿using Blog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class Image:EntityBase
    {
        public Image()
        {
            
        }
        public Image(string fileName,string fileType,string createdBy,string fullPath)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;  
            FullPath = fullPath;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
		public string FullPath { get; set; }
		public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
    }
}
