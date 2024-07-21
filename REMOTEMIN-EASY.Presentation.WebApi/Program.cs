using REMOTEMIND_EASY.Infrastructure.Persistence;
using REMOTEMIND_EASY.Infrastructure.Identity;
using REMOTEMIN_EASY.Presentation.WebApi.Extensions;
using REMOTEMIND_EASY.Core.Application;
using Microsoft.AspNetCore.Identity;
using REMOTEMIND_EASY.Infrastructure.Identity.Entities;
using REMOTEMIND_EASY.Infrastructure.Identity.Seeds;
using REMOTEMIND_EASY.Core.Application.Interfaces.Repositories;
using REMOTEMIND_EASY.Infrastructure.Persistence.Seeds;
using REMOTEMIND_EASY.Infrastructure.Persistence.Repositories;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddInfrastructureIdentity(builder.Configuration);
builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddApiVersioningExtension();
builder.Services.AddSwaggerExtension();
builder.Services.AddHealthChecks();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddAuthorization();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var userManager = provider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
    var context = provider.GetRequiredService<ApplicationContext>();
    try
    {
        await DefaultRoles.SeedAsync(userManager, roleManager);
        await EnterpriseUser.SeedAsync(userManager, roleManager);
        await EmployeeUser.SeedAsync(userManager, roleManager);
        await DefaultQuestions.SeeAsync(context);
        await DefaultResponses.SeeAsync(context);
    }
    catch (Exception e)
    {
        // Log the exception
        Console.WriteLine(e.Message);
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "REMOTEMIND-EASY");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware();
app.UseHealthChecks("/health");
app.UseSession();
app.MapControllers();

app.Run();
