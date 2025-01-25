using Microsoft.EntityFrameworkCore;
using PostManagementSystem.Mapping;

namespace PostManagementSystem.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options) { }

        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new PostMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
