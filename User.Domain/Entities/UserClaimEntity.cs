using Microsoft.AspNetCore.Identity;

namespace User.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class UserClaimEntity : IdentityUserClaim<Guid>
{
    /// <summary>
    /// Role description
    /// </summary>
    public string Description { get; set; }
}