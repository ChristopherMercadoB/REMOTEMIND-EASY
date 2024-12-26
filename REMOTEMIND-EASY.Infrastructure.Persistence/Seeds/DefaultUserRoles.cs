using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultUserRoles
    {
        public static async Task SeedAsync(ApplicationContext context)
        {
            if (!await context.Set<Role>().AnyAsync())
            {
                await context.Set<Role>().AddRangeAsync(
                    new Role { Name = "Enterprise", Description = "The manager of the institute"},
                    new Role { Name = "Employee", Description = "Employee who gonna do the test" }
                );

                await context.SaveChangesAsync();

            }

        }
    }
}
