using Microsoft.AspNetCore.Identity;
using REMOTEMIND_EASY.Core.Application.Enums;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;

namespace REMOTEMIND_EASY.Infrastructure.Identity.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           await roleManager.CreateAsync(new IdentityRole(Roles.Enterprise.ToString()));
           await roleManager.CreateAsync(new IdentityRole(Roles.Employee.ToString()));
        }
    }
}
