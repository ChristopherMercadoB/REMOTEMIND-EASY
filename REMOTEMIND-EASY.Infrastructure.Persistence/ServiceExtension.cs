using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using REMOTEMIND_EASY.Infrastructure.Persistence.Repositories;


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
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IResponseRepository, ResponseRepository>();
            services.AddTransient<IUserResponseRepository, UserResponseRepository>();
            services.AddTransient<IResultRepository, ResultRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            #endregion
        }
    }
}
