using Microsoft.AspNetCore.Identity;
using Shared.Infrastructure.Interfaces;

namespace Shared.Infrastructure.Services;

/// <summary>
/// User service
/// </summary>
/// <typeparam name="TUser"> User type </typeparam>
public class UserService<TUser> : IUserService<TUser> where TUser : IdentityUser<Guid>
{
    private readonly UserManager<TUser> _userManager;

    public UserService(UserManager<TUser> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Get current user id
    /// </summary>
    /// <param name="user"> User </param>
    /// <returns></returns>
    public async Task<Guid> GetCurrentUserId(TUser user)
        => Guid.Parse(await _userManager.GetUserIdAsync(user));
}