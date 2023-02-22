namespace Shared.Core.Entities;

public class AuditableEntity : IAuditableEntity
{
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