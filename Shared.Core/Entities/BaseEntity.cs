/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace Shared.Core.Entities;

public class BaseEntity : IBaseEntity, IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
        
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