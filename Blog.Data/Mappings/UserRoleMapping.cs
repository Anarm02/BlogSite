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
    public class UserRoleMapping : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(new AppUserRole
            {
                RoleId = Guid.Parse("174152D8-E285-42ED-AC05-8D41DAE118C4"),
                UserId = Guid.Parse("60F812E7-9374-4623-873B-C28D9F6437E4")
            },
            new AppUserRole
            {
                RoleId= Guid.Parse("22428D23-2CE0-4D33-8B57-82A2C649AB04"),
                UserId= Guid.Parse("FA2CC9C4-4293-4A01-95CD-F67A85A744D2")
            }
            );
        }
    }
}
