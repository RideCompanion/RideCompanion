using Microsoft.Extensions.Configuration;

namespace Shared.Infrastructure.Helpers;

public static class ConfigurationHelper
{
    public static IConfiguration AppSetting { get; }

    static ConfigurationHelper() =>
        AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
}