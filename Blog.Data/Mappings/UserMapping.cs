using Blog.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(u => u.Id);

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
            builder.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

            // Maps to the AspNetUsers table
            builder.ToTable("AspNetUsers");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Limit the size of columns to use efficient database types
            builder.Property(u => u.UserName).HasMaxLength(256);
            builder.Property(u => u.NormalizedUserName).HasMaxLength(256);
            builder.Property(u => u.Email).HasMaxLength(256);
            builder.Property(u => u.NormalizedEmail).HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            // Each User can have many UserClaims
            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            var superadmin=new AppUser
            {
                Id = Guid.Parse("60F812E7-9374-4623-873B-C28D9F6437E4"),
                UserName="superadmin@gmail.com",
                NormalizedUserName="SUPERADMIN@GMAIL.COM",  
                Email= "superadmin@gmail.com",
                NormalizedEmail="SUPERADMIN@GMAIL.COM",  
                PhoneNumber="+9940506983552",
                FirstName="Anar",
                LastName="Mammadli",
                PhoneNumberConfirmed=true,
                EmailConfirmed=true,
                SecurityStamp=Guid.NewGuid().ToString()
            };
            superadmin.PasswordHash = CreatePasswordHash(superadmin,"Anar1234");
            var admin = new AppUser
            {
                Id = Guid.Parse("FA2CC9C4-4293-4A01-95CD-F67A85A744D2"),
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                PhoneNumber = "+9940506983542",
                FirstName = "Anr",
                LastName = "Mammdli",
                PhoneNumberConfirmed = false,
                EmailConfirmed = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            admin.PasswordHash = CreatePasswordHash(admin, "admin1234");
            builder.HasData(superadmin, admin);


        }
        private string CreatePasswordHash(AppUser user,string password)
        {
            var passwordhash = new PasswordHasher<AppUser>();
            return passwordhash.HashPassword(user, password);
        }
    }
}
