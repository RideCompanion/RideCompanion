/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Dto;
using Trip.Domain.Dto;
#pragma warning disable CS8618

namespace RideCompanion.ViewModels;

/// <summary>
/// Driver view model
/// </summary>
public class DriverViewModel
{
    /// <summary>
    /// Driver dto
    /// </summary>
    public DriverDto DriverDto { get; set; }
        
    /// <summary>
    /// Drivers list
    /// </summary>
    public List<DriverDto> Drivers { get; set; }
        
    /// <summary>
    /// Car dto
    /// </summary>
    public CarDto CarDto { get; set; }
        
    /// <summary>
    /// Cars list
    /// </summary>
    public List<CarDto>? Cars { get; set; }
        
    /// <summary>
    /// Trip dto
    /// </summary>
    public TripDto? TripDto { get; set; }
        
    /// <summary>
    /// Trips list
    /// </summary>
    public List<TripDto>? Trips { get; set; }
}