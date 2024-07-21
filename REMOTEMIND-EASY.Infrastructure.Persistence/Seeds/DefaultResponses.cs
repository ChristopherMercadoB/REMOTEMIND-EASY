using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;

namespace REMOTEMIND_EASY.Infrastructure.Persistence.Seeds
{
    public static class DefaultResponses
    {
        public static async Task SeeAsync(IResponseRepository res)
        {
            var response = await res.GetAllAsync();
            if (response == null || response.Count <= 0)
            {
                await res.AddAsync(new Core.Domain.Entities.Responses() { Name = "Nunca", Value = 0 });
                await res.AddAsync(new Core.Domain.Entities.Responses() { Name = "Casi Nunca", Value = 25 });
                await res.AddAsync(new Core.Domain.Entities.Responses() { Name = "A veces", Value = 50 });
                await res.AddAsync(new Core.Domain.Entities.Responses() { Name = "A menudo", Value = 75 });
                await res.AddAsync(new Core.Domain.Entities.Responses() { Name = "Muy A menudo", Value = 100 });
            }
        }
    }
}
