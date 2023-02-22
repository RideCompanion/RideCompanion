using Driver.Domain.Dto;
using Trip.Domain.Dto;

namespace RideCompanion.ViewModels;

/// <summary>
/// Driver view model
/// </summary>
public class DriverViewModel
{
    /// <summary>
    /// Driver
    /// </summary>
    public DriverDto? DriverDto { get; set; }
        
    /// <summary>
    /// Drivers list
    /// </summary>
    public List<DriverDto>? Drivers { get; set; }
        
    /// <summary>
    /// Car
    /// </summary>
    public CarDto? CarDto { get; set; }
        
    /// <summary>
    /// Cars list
    /// </summary>
    public List<CarDto>? Cars { get; set; }
        
    /// <summary>
    /// Trip
    /// </summary>
    public TripDto? TripDto { get; set; }
        
    /// <summary>
    /// Trips list
    /// </summary>
    public List<TripDto>? Trips { get; set; }
}