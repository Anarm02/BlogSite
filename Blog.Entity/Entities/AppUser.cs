using Blog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Entity.Entities
{
    public class AppUser:IdentityUser<Guid>,IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid ImageId { get; set; } = Guid.Parse("405228a6-1d28-4569-a5ef-3a71df3cdb41");

		public Image Image { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
