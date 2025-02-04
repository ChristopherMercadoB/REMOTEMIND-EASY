using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using REMOTEMIND_EASY.Core.Application.Interfaces.Services;
using REMOTEMIND_EASY.Core.Application.Services;
using System.Reflection;

namespace REMOTEMIND_EASY.Core.Application
{
    public static class ServiceExtension
    {
        public static void AddCoreApplication(this IServiceCollection services, IConfiguration configuration)
        {
            #region Packages Inyection
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            #endregion

            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IResponseService, ResponseService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IUserResponseService, UserResponseService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<ICommentService, CommentService>();
            #endregion
        }
    }
}
