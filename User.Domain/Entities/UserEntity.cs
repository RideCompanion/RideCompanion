/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.ComponentModel.DataAnnotations;
using Shared.Abstractions.Entities;

namespace User.Domain.Entities;

public class UserEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
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
    /// Email
    /// </summary>
    public string? Email { get; set; }
    
    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// User claims
    /// </summary>
    public IList<UserClaimEntity>? Claims { get; set; }
    
    /// <summary>
    /// User roles
    /// </summary>
    public ICollection<RoleEntity> Roles { get; set; }

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