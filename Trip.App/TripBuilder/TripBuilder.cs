/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Dto;
using Driver.Domain.Dto;
using Trip.Domain.Dto;
#pragma warning disable CS8618

namespace Trip.App.TripBuilder;

/// <summary>
/// Trip builder
/// </summary>
public class TripBuilder : ITripBuilder
{
    private TripDto _trip;
    
    public TripBuilder(TripDto? trip)
    {
        _trip = trip ?? new TripDto();
    }
    
    public TripBuilder()
    {
    }

    /// <summary>
    /// Set current trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    public TripDto SetCurrentTrip(TripDto tripDto)
    {
        _trip = tripDto;
        return _trip;
    }

    /// <summary>
    /// Add driver to trip
    /// </summary>
    /// <param name="driverDto">Driver dto</param>
    /// <param name="carDto">Car dto</param>
    /// <returns>Trip dto</returns>
    public TripDto AddDriver(DriverDto driverDto, CarDto carDto)
    {
        _trip.Driver = driverDto;
        _trip.Car = carDto;
        return _trip;
    }

    /// <summary>
    /// Add companion to trip
    /// </summary>
    /// <param name="companionDto">Companion dto</param>
    /// <returns>Trip dto</returns>
    public TripDto AddCompanion(CompanionDto companionDto)
    {
        _trip.Companion = companionDto;
        return _trip;
    }

    /// <summary>
    /// Get trip
    /// </summary>
    /// <returns>Trip dto</returns>
    public TripDto GetTrip() => _trip;
}