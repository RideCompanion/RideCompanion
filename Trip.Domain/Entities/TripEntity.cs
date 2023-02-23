/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Shared.Abstractions.Entities;

namespace Trip.Domain.Entities;

/// <summary>
/// Trip entity
/// </summary>
public class TripEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Companion Id
    /// </summary>
    public Guid? CompanionId { get; set; }
    
    /// <summary>
    /// Car
    /// </summary>
    public Guid? CarId { get; set; }
    
    /// <summary>
    /// User Id
    /// </summary>
    public Guid? DriverId { get; set; }
    
    /// <summary>
    /// Address from
    /// </summary>
    public string? AddressFrom { get; set; }
    
    /// <summary>
    /// Address to
    /// </summary>
    public string? AddressTo { get; set; }
    
    /// <summary>
    /// Trip date time
    /// </summary>
    public DateTime DateTime { get; set; }

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