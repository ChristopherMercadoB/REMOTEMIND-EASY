using Microsoft.AspNetCore.Identity;
using REMOTEMIND_EASY.Core.Application.Enums;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;


namespace REMOTEMIND_EASY.Infrastructure.Identity.Seeds
{
    public static class EmployeeUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new()
            {
                Name = "Pedro Alexis",
                Identification = "40234010963",
                UserName = "Pedro",
                Email = "pedro@email.com",
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
