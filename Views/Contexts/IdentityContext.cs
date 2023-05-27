using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Views.Models.Entities;
using Views.Models.Identity;
using Views.Services;

namespace Views.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>

    {  

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductsCategory> ProductsCategory { get; set; }
        public DbSet<ProfileData> Profiles { get; set; }
        public DbSet<ContactFormEntity> ContactForm { get; set; }

    }
}
