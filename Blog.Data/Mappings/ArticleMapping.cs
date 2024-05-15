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
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(150);
            builder.HasData(new Article
            {
                Id = Guid.NewGuid(),
                Title = "Asp.net Core Article 1",
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.",
                ViewCount = 15,
                CategoryId = Guid.Parse("{F77FC9BC-B838-4745-93BF-17564A78DFC9}"),
                ImageId = Guid.Parse("{7DE25A1B-6C11-4AA3-9974-172C52571B2E}"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                UserId= Guid.Parse("60F812E7-9374-4623-873B-C28D9F6437E4")
            },
            new Article
            {
                Id = Guid.NewGuid(),
                Title = "Visual Studio Article 1",
                Content = " VSLorem ipsum dolor sit amet, consectetur adipiscing elit. Nulla a interdum sapien. Fusce eget lectus sit amet dui convallis feugiat nec et quam. Integer massa purus, dictum et vestibulum eget, ullamcorper ac diam. Cras varius sed eros in iaculis. Cras posuere dignissim purus nec porta. Phasellus vehicula at justo eu finibus. Mauris eget tempus nulla, vitae porta neque. Praesent in ornare magna. Phasellus diam dolor, consectetur ut eros id, feugiat aliquam turpis. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce ut tortor sit amet orci auctor pellentesque eget tristique augue. Aliquam et viverra tellus, ac hendrerit massa. Pellentesque rhoncus nisl non dolor tempor, malesuada convallis enim cursus. Aenean consequat ex dui, sed bibendum orci semper et.",
                ViewCount = 14,
                CategoryId = Guid.Parse("{E35E8B13-C92F-4720-BB44-BD0536925B08}"),
                ImageId = Guid.Parse("{3A94E829-4A63-4598-8BD7-80AEDA1EEF6A}"),
                CreatedBy = "Admin Test",
                CreatedDate = DateTime.Now,
                UserId = Guid.Parse("FA2CC9C4-4293-4A01-95CD-F67A85A744D2")
            });
        }
    }
}
