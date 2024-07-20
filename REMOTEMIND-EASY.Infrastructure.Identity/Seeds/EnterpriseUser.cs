using Microsoft.AspNetCore.Identity;
using REMOTEMIND_EASY.Core.Application.Enums;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Identity.Seeds
{
    public static class EnterpriseUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new()
            {
                UserName = "Enterprise",
                Email = "enterprise@email.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(e => e.Id == defaultUser.Id))
            {
                if (userManager.FindByEmailAsync(defaultUser.Email) == null)
                {
                    await userManager.CreateAsync(defaultUser, "Pa$$word123!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Enterprise.ToString());
                }
            }
        }
    }
}
