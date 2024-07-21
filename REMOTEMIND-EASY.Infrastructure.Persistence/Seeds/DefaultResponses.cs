using Microsoft.EntityFrameworkCore;
using REMOTEMIND_EASY.Core.Domain.Entities;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultResponses
    {
        public static async Task SeeAsync(ApplicationContext context)
        {
            if (!await context.Set<Responses>().AnyAsync())
            {
                await context.Responses.AddRangeAsync(
                    new Responses() { Name = "Nunca", Value = 0 },
                    new Responses() { Name = "Casi Nunca", Value = 25 },
                    new Responses() { Name = "A Veces", Value = 50 },
                    new Responses() { Name = "A menudo", Value = 75 },
                    new Responses() { Name = "Muy A Menudo", Value = 100 }
                    );

                await context.SaveChangesAsync();


            }
        }
    }
}
