using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace REMOTEMIND_EASY.Core.Application
{
    public static class ServiceExtension
    {
        public static void AddCoreApplication(IServiceCollection services, IConfiguration configuration)
        {
            #region Packages Inyection
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion
        }
    }
}
