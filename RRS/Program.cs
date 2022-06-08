using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using RRS.Data;
using RRS.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Generated by identity scaffold

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Password.RequireNonAlphanumeric = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireLowercase= false;
    o.Password.RequireDigit= false;
    o.Password.RequiredLength = 2;
});


builder.Services.AddScoped<PersonService>();

builder.Services.AddControllersWithViews();

//Adding scope for getting logged in user ID
builder.Services.AddScoped<IUserService, UserService>();

// Adds both cookie and JWT Bearer token based authentication, so that you can still sign in using the website.
// The policy scheme is used to determine which authentication scheme should be used so that both will work.
builder.Services.AddAuthentication(o =>
        {
            o.DefaultScheme = "JWT_OR_COOKIE";
            o.DefaultChallengeScheme = "JWT_OR_COOKIE";
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),

                // Prevents tokens without an expiry from ever working, as that would be a security vulnerability.
                RequireExpirationTime = true,

                // ClockSkew generally exists to account for potential clock difference between issuer and consumer
                // But we are both, so we don't need to account for it.
                // For all intents and purposes, this is optional
                ClockSkew = TimeSpan.Zero
            };
        })
        .AddPolicyScheme("JWT_OR_COOKIE", null, o =>
        {
            o.ForwardDefaultSelector = c =>
            {
                string auth = c.Request.Headers[HeaderNames.Authorization];
                if (!string.IsNullOrWhiteSpace(auth) && auth.StartsWith("Bearer "))
                {
                    return JwtBearerDefaults.AuthenticationScheme;
                }

                return IdentityConstants.ApplicationScheme;
            };
        });

var app = builder.Build();

// global cors policy
app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
});
//.SetIsOriginAllowed(origin => true)); // allow any origin - bypass react api request blocked by CORS policy

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
    string[] reactRoutes = {"/people","/date","/sitting","/details" ,"/Confirmation" }; 

    if (context.Response.StatusCode == 404 && reactRoutes.Any(p => p.Equals(context.Request.Path)))
    {
        context.Request.Path = "/Home";
        await next();
    }
    else if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Home/BeanError"; 
        await next();
    }
});



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}");

app.MapRazorPages();

app.Run();
