using REMOTEMIND_EASY.Core.Application;
using REMOTEMIND_EASY.Infrastructure.Persistence;
using REMOTEMIND_EASY.Infrastructure.Identity;
using REMOTEMIND_EASY.Infrastructure.Persistence.Context;
using REMOTEMIND_EASY.Infrastructure.Persistence.Seeds;
using REMOTEMIND_EASY.Infrastructure.MachineLearning;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddInfrastructurePersistence(builder.Configuration);
builder.Services.AddCoreApplication(builder.Configuration);
builder.Services.AddInfrastructureIdentity(builder.Configuration);
builder.Services.AddInfrastructureMachineLearning(builder.Configuration);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    var context = provider.GetRequiredService<ApplicationContext>();
    try
    {
        await DefaultUserRoles.SeedAsync(context);
        await DefaultQuestions.SeedAsync(context);
        await DefaultResponses.SeedAsync(context);
        await DefaultUser.SeedAsync(context);
    }
    catch (Exception e)
    {
        throw new Exception(e.InnerException?.Message);
    }
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
