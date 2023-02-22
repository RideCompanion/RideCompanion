using Shared.Core.Entities;

namespace Driver.Domain.Entities;

/// <summary>
/// Car
/// </summary>
public class CarEntity : IBaseEntity, IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// User
    /// </summary>
    public string? UserId { get; set; }
    
    /// <summary>
    /// Driver
    /// </summary>
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Car number
    /// </summary>
    public string? Number { get; set; }
    
    /// <summary>
    /// Car color
    /// </summary>
    public string? Color { get; set; } = null!;

    /// <summary>
    /// Car model
    /// </summary>
    public string? Model { get; set; } = null!;

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