using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REMOTEMIND_EASY.Core.Domain.Settings;


namespace REMOTEMIND_EASY.Infrastructure.Shared
{
    public static class ServiceExtension
    {
        public static void AddInfrastructureShared(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MailSettings>(configuration.GetSection("MailSetting"));
        }
    }
}
