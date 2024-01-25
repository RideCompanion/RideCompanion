namespace Shared.Infrastructure.Interfaces;

/// <summary>
/// User service
/// </summary>
/// <typeparam name="TUser"> User type </typeparam>
public interface IUserService<in TUser>
{
    /// <summary>
    /// Get current user id
    /// </summary>
    /// <param name="user"> User </param>
    /// <returns></returns>
    Task<Guid> GetCurrentUserId(TUser user);
}