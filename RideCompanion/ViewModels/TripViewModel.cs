using Trip.Domain.Dto;

namespace RideCompanion.ViewModels;

/// <summary>
/// Trip
/// </summary>
public class TripViewModel
{
    /// <summary>
    /// Trip
    /// </summary>
    public TripDto? TripDto { get; set; }
        
    /// <summary>
    /// Trip list
    /// </summary>
    public List<TripDto>? Trips { get; set; }
}