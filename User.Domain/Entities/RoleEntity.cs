/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.ComponentModel.DataAnnotations;
using Shared.Abstractions.Entities;

namespace User.Domain.Entities;

/// <summary>
/// Role entity
/// </summary>
public class RoleEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// Role name
    /// </summary>
    public String? RoleName { get; set; }
    
    /// <summary>
    /// User Id
    /// </summary>
    public Guid UserId { get; set; }
    public UserEntity User { get; set; }
    
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