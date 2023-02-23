/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Microsoft.AspNetCore.Identity;
using Shared.Abstractions.Entities;

namespace User.Domain.Entities;

/// <summary>
/// User entity
/// </summary>
public class UserEntity : IdentityUser<Guid>, IBaseEntity
{
    /// <summary>
    /// Full User Name
    /// </summary>
    public string? FullUserName { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }

    /// <summary>
    /// Id created user
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Created date
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Id updated user
    /// </summary>
    public Guid UpdateById { get; set; }

    /// <summary>
    /// Update date
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Is deleted flag
    /// </summary>
    public bool IsDeleted { get; set; }
}