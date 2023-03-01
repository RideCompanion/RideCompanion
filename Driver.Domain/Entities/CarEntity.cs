/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Shared.Abstractions.Entities;
#pragma warning disable CS8618

namespace Driver.Domain.Entities;

/// <summary>
/// Car entity
/// </summary>
public class CarEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Driver
    /// </summary>
    public Guid DriverId { get; set; }
    public DriverEntity Driver { get; set; }
    
    /// <summary>
    /// Car number
    /// </summary>
    public string? Number { get; set; }
    
    /// <summary>
    /// Car color
    /// </summary>
    public string? Color { get; set; }
    
    /// <summary>
    /// Make of car
    /// </summary>
    public string? Brand { get; set; }

    /// <summary>
    /// Model of car
    /// </summary>
    public string? Model { get; set; }
    
    /// <summary>
    /// Car model Id
    /// </summary>
    public Guid CarModelId { get; set; }
    public CarModelEntity CarModel { get; set; }

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