using IdentityUser.Domain.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Infrastructure.Interfaces;
using Shared.Infrastructure.Services;
using Shared.Migrations;

namespace RIdeCompanion.Extensions;

/// <summary>
/// Database and identity extension
/// </summary>
public static class DbExtension
{
    /// <summary>
    /// Configure database and identity
    /// </summary>
    /// <param name="builder"> Web application builder </param>
    /// <param name="connectionString"> Connection string </param>
    public static void ConfigureDatabaseAndIdentity(WebApplicationBuilder builder, string connectionString)
    {
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
        builder.Services.AddSingleton<IDapperContext, DapperContext>();

        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        builder.Services.AddIdentity<AppUserEntity, AppRoleEntity>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

        builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        builder.Services.AddScoped<IUserService<AppUserEntity>, UserService<AppUserEntity>>();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddGoogle(options =>
            {
                options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
                options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
            });
    }
}