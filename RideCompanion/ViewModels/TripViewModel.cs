/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Trip.Domain.Dto;

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
}