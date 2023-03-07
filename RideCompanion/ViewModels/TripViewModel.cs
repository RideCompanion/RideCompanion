/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Dto;
using Companion.Domain.Dto;
using Driver.Domain.Dto;
using Trip.Domain.Dto;
#pragma warning disable CS8618

namespace RideCompanion.ViewModels;

/// <summary>
/// Trip view model
/// </summary>
public class TripViewModel
{
    /// <summary>
    /// Trip dto
    /// </summary>
    public TripDto? TripDto { get; set; }
        
    /// <summary>
    /// Trip list
    /// </summary>
    public List<TripDto>? Trips { get; set; }
    
    /// <summary>
    /// Driver dto
    /// </summary>
    public DriverDto DriverDto { get; set; }
    
    /// <summary>
    /// Driver Id
    /// </summary>
    public Guid DriverId { get; set; }
        
    /// <summary>
    /// Drivers list
    /// </summary>
    public List<DriverDto> Drivers { get; set; }
        
    /// <summary>
    /// Car dto
    /// </summary>
    public CarDto CarDto { get; set; }
    
    /// <summary>
    /// Car Id
    /// </summary>
    public Guid CarId { get; set; }
        
    /// <summary>
    /// Cars list
    /// </summary>
    public List<CarDto>? Cars { get; set; }
    
    /// <summary>
    /// Companion dto
    /// </summary>
    public CompanionDto? CompanionDto { get; set; }
        
    /// <summary>
    /// Companion list
    /// </summary>
    public List<CompanionDto>? Companions { get; set; }
    
    /// <summary>
    /// Driver dto
    /// </summary>
    public DriverDto? DriverDto { get; set; }
        
    /// <summary>
    /// Driver list
    /// </summary>
    public List<DriverDto>? Drivers { get; set; }
    
    /// <summary>
    /// Car dto
    /// </summary>
    public CarDto? CarDto { get; set; }
        
    /// <summary>
    /// Car list
    /// </summary>
    public List<CarDto>? Cars { get; set; }
}