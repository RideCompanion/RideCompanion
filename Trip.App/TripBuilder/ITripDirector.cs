/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

/// <summary>
/// Trip director interface
/// </summary>
public interface ITripDirector
{
    /// <summary>
    /// Add companion to trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    TripDto AddCompanionToTrip(TripDto tripDto);
    
    /// <summary>
    /// Add driver to trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    TripDto AddDriverToTrip(TripDto tripDto);
    
    /// <summary>
    /// Build full trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    TripDto BuildTrip(TripDto tripDto);
}