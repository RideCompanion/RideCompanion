namespace Shared.Infrastructure.Interfaces;

/// <summary>
/// Redis cache service
/// </summary>
public interface IRedisCacheService
{
    /// <summary>
    /// Get data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <typeparam name="T"> Type </typeparam>
    /// <returns> Data </returns>
    T? GetData<T>(string key);
    
    /// <summary>
    /// Set data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <param name="value"> Value </param>
    /// <param name="expirationTime"> Expiration time </param>
    /// <typeparam name="T"> Type </typeparam>
    /// <returns> True if success else false </returns>
    bool SetData<T>(string key, T value, DateTimeOffset expirationTime);
    
    /// <summary>
    /// Remove data
    /// </summary>
    /// <param name="key"> Key </param>
    /// <returns> True if success else false </returns>
    object RemoveData(string key);
}