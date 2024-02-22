using IdentityUser.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace RIdeCompanion.Extensions;

/// <summary>
/// Services extension
/// </summary>
public static class ServicesExtension
{
    public static void AddServices(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddScoped<UserManager<AppUserEntity>>();
        webApplicationBuilder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
    }
}