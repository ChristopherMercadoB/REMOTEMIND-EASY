using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;


namespace REMOTEMIND_EASY.Infrastructure.Persistence
{
    public static class ServiceExtension
    {
        public static void AddInfrastructurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("InMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(op => op.UseInMemoryDatabase("InMemoryDB"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(op => op.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            #endregion
        }
    }
}
