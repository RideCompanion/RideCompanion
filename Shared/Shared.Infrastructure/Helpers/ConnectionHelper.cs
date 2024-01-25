using StackExchange.Redis;

namespace Shared.Infrastructure.Helpers;

public class ConnectionHelper
{
    static ConnectionHelper() => LazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        ConnectionMultiplexer.Connect(ConfigurationHelper.AppSetting["RedisCacheService"] ?? string.Empty));

    private static readonly Lazy<ConnectionMultiplexer> LazyConnection;
    public static ConnectionMultiplexer Connection => LazyConnection.Value;
}