using Shared.Infrastructure.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using Shared.Infrastructure.Helpers;
#pragma warning disable CS8604

namespace Shared.Infrastructure.Services;

/// <summary>
/// Redis cache service
/// </summary>
public class RedisCacheService : IRedisCacheService
{
    private IDatabase _db;

    public RedisCacheService(IDatabase db)
    {
        _db = db;
        ConfigureRedis();
    }

    /// <summary>
    /// Get data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <typeparam name="T"> Type </typeparam>
    /// <returns> Data </returns>
    public T? GetData<T>(string key)
    {
        var value = _db.StringGet(key);
        return !string.IsNullOrEmpty(value)
            ? JsonConvert.DeserializeObject<T>(value)
            : default;
    }

    /// <summary>
    /// Set data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <param name="value"> Value </param>
    /// <param name="expirationTime"> Expiration time </param>
    /// <typeparam name="T"> Type </typeparam>
    /// <returns> True if success else false </returns>
    public bool SetData<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        return _db.StringSet(key, JsonConvert.SerializeObject(value), expiryTime);
    }

    /// <summary>
    /// Remove data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <returns> True if success else false </returns>
    public object RemoveData(string key)
    {
        var isKeyExist = _db.KeyExists(key);
        return isKeyExist && _db.KeyDelete(key);
    }

    /// <summary>
    /// Configure redis
    /// </summary>
    private void ConfigureRedis()
    {
        _db = ConnectionHelper.Connection.GetDatabase();
    }
}