using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Shared.Core.Entities;

namespace Trip.Domain.Entities;

/// <summary>
/// Trip
/// </summary>
public class TripEntity : BaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public DriverEntity? Driver { get; set; }
    
    /// <summary>
    /// Companion
    /// </summary>
    public CompanionEntity? Companion { get; set; }
    
    /// <summary>
    /// Car
    /// </summary>
    public CarEntity? Car { get; set; }
    
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
}