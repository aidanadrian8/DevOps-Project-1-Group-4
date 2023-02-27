using devops_project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace devops_project.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {

        public ApplicationDbContext()
        {

        }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions) : base(contextOptions) {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<Plant> Plant { get; set; }

        public DbSet<Part> Part { get; set; }
    }
}
