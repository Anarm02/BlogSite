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
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = Guid.Parse("{F77FC9BC-B838-4745-93BF-17564A78DFC9}"),
                Name="Asp.net Core",
                CreatedBy="Admin Test",
                IsDeleted=false,
                CreatedDate=DateTime.Now
            },
            new Category
            {
                Id = Guid.Parse("{E35E8B13-C92F-4720-BB44-BD0536925B08}"),
                Name = "Visual Studio 2022",
                CreatedBy = "Admin Test",
                IsDeleted = false,
                CreatedDate = DateTime.Now
            });
        }
    }
}
