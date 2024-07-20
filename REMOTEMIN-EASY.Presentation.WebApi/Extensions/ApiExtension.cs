using REMOTEMIN_EASY.Presentation.WebApi.Middleware;

namespace REMOTEMIN_EASY.Presentation.WebApi.Extensions
{
    public static class ApiExtension
    {
        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }

        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "REMOTEMIND-EASY");
            });
        }
    }
}
