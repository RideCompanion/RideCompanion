using System.Diagnostics;
using Shared.Infrastructure.Interfaces;
using Shared.Infrastructure.Services;
using StackExchange.Redis;

namespace RIdeCompanion.Extensions;

/// <summary>
/// Redis cache extension
/// </summary>
public static class RedisCacheExtension
{
    /// <summary>
    /// Configure Redis cache
    /// </summary>
    /// <param name="webApplicationBuilder"> Web application builder </param>
    public static void ConfigureRedisCache(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Services.AddStackExchangeRedisCache(options => options.Configuration = webApplicationBuilder.Configuration["RedisCacheService"]!);

        webApplicationBuilder.Services.AddScoped<IDatabase>(provider =>
        {
            var redis = provider.GetService<IConnectionMultiplexer>();
            Debug.Assert(redis != null, nameof(redis) + " != null");
            return redis.GetDatabase();
        });

        webApplicationBuilder.Services.AddScoped<IRedisCacheService, RedisCacheService>();
    }
}