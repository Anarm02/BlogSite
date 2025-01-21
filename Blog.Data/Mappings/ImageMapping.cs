using Blog.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasData(new Image
            {
                Id = Guid.Parse("{7DE25A1B-6C11-4AA3-9974-172C52571B2E}"),
                FileName = "images/testImage",
                FileType = "jpg",
                FullPath= @"D:\Backend\Projects\BlogSite\Blog.Web\wwwroot\images\article-images\efjfnerjnewefef_899.png",

				CreatedBy = "Admin Test",
                IsDeleted = false,
                CreatedDate = DateTime.Now
            },
            new Image
            {
                Id = Guid.Parse("{3A94E829-4A63-4598-8BD7-80AEDA1EEF6A}"),
                FileName = "images/VsImage",
                FileType = "png",
                FullPath= @"D:\Backend\Projects\BlogSite\Blog.Web\wwwroot\images\article-images\gerwgnerjgnerwnkg_814.png",

				CreatedBy = "Admin Test",
                IsDeleted = false,
                CreatedDate = DateTime.Now,
               
                
            }
            );
        }
    }
}
