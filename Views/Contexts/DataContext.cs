using Microsoft.EntityFrameworkCore;
using Views.Models.Entities;

namespace Views.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProfileEntity> Profiles { get; set; }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
