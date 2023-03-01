using Microsoft.AspNetCore.Identity;
#pragma warning disable CS8618

namespace User.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class RoleEntity : IdentityRole<Guid>
{
    /// <summary>
    /// Role description
    /// </summary>
    public string Description { get; set; }
}