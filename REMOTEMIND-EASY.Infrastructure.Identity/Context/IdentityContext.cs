using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;


namespace REMOTEMIND_EASY.Infrastructure.Identity.Context
{
    public class IdentityContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> op ):base(op)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.HasDefaultSchema("Identity");
            model.Entity<ApplicationUser>().ToTable(name: "User");
            model.Entity<IdentityRole>().ToTable(name: "Role");
            model.Entity<IdentityUserRole<string>>().ToTable(name: "UserRole");
            model.Entity<IdentityUserLogin<string>>().ToTable(name: "UserLogin");
        }
    }
}
