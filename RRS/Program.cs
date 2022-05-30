using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RRS.Data;
using RRS.Services;
using NLog;
using NLog.Web;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
        .AddEntityFrameworkStores<ApplicationDbContext>();

    builder.Services.AddScoped<PersonService>();

    builder.Services.AddControllersWithViews();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.Use(async (context, next) =>
    {
        await next();
    //
    string[] reactRoutes = { "/people", "/date", "/sitting", "/details", "/Confirmation" };

        if (context.Response.StatusCode == 404 && reactRoutes.Any(p => p.Equals(context.Request.Path)))
        {
            context.Request.Path = "/Home";
            await next();
        }
    });

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    // global cors policy
    app.UseCors(x => x
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true)); // allow any origin - bypass react api request blocked by CORS policy - Atif
                                              // possible HACK, review prior to publishing application

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

    app.MapRazorPages();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
