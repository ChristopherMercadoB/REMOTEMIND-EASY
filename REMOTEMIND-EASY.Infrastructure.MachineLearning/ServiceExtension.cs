using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMOTEMIND_EASY.Infrastructure.MachineLearning
{
    public static class ServiceExtension
    {
        public static void AddInfrastructureMachineLearning(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IMachineLearningService, MachineLearningService>();
        }
    }
}
