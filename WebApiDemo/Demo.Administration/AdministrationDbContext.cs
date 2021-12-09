using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Administration
{
    public class AdministrationDbContext : IdentityDbContext<ApplicationUser>
    {
        public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new[]
            {
                new IdentityRole("user"),
                new IdentityRole("admin")
            });
        }
    }
}
