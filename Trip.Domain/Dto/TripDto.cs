using Companion.Domain.Dto;
using Driver.Domain.Dto;

namespace Trip.Domain.Dto;

/// <summary>
/// Trip
/// </summary>
public class TripDto
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Driver
    /// </summary>
    public DriverDto? Driver { get; set; } = null;
    
    /// <summary>
    /// Companion
    /// </summary>
    public CompanionDto? Companion { get; set; } = null;
    
    /// <summary>
    /// Car
    /// </summary>
    public CarDto? Car { get; set; } = null;
    
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