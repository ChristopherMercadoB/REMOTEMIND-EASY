using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Application.Helpers;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if (!await context.Set<User>().AnyAsync())
            {
                await context.Set<User>().AddAsync(
                    new User
                    {

                        Name = "Enterprise",
                        Username = "Admin",
                        RoleId = 1,
                        Password = PasswordEncryption.HashPassword("admin123")

                    }

                ) ;

                await context.SaveChangesAsync();

            }

        }
    }
}
