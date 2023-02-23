/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Dto;
using Driver.Domain.Dto;
using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

/// <summary>
/// Trip builder interface
/// </summary>
public interface ITripBuilder
{
    /// <summary>
    /// Set current trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    TripDto SetCurrentTrip(TripDto tripDto);
    
    /// <summary>
    /// Add driver to trip
    /// </summary>
    /// <param name="driverDto">Driver dto</param>
    /// <param name="carDto">Car dto</param>
    /// <returns>Trip dto</returns>
    TripDto AddDriver(DriverDto driverDto, CarDto carDto);
    
    /// <summary>
    /// Add companion to trip
    /// </summary>
    /// <param name="companionDto">Companion dto</param>
    /// <returns>Trip dto</returns>
    TripDto AddCompanion(CompanionDto companionDto);
    
    /// <summary>
    /// Get trip
    /// </summary>
    /// <returns>Trip dto</returns>
    TripDto GetTrip();
}