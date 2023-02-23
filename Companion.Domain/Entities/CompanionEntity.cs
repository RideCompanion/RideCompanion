/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Shared.Abstractions.Entities;

namespace Companion.Domain.Entities;

/// <summary>
/// Companion entity
/// </summary>
public class CompanionEntity : IBaseEntity, IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// User Id
    /// </summary>
    public Guid UserId { get; set; }
    
    /// <summary>
    /// Full name
    /// </summary>
    public string? FullName { get; set; }
    
    /// <summary>
    /// Birth date
    /// </summary>
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Created user Id
    /// </summary>
    public Guid CreatedById { get; set; }
    
    /// <summary>
    /// Create date
    /// </summary>
    public DateTime CreateDate { get; set; }
    
    /// <summary>
    /// Update user Id
    /// </summary>
    public Guid UpdateById { get; set; }
    
    /// <summary>
    /// Update date
    /// </summary>
    public DateTime UpdateDate { get; set; }
    
    /// <summary>
    /// Is deleted
    /// </summary>
    public bool IsDeleted { get; set; }
}