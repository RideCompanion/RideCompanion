/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace Driver.Domain.Dto;

/// <summary>
/// Car Dto
/// </summary>
public class CarDto
{
    public Guid Id { get; set; }
    
    /// <summary>
    /// User Id
    /// </summary>
    public string? UserId { get; set; }
    
    /// <summary>
    /// Driver Id
    /// </summary>
    public Guid DriverId { get; set; }
    
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