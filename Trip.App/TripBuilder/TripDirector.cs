/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

/// <summary>
/// Trip director
/// </summary>
public class TripDirector : ITripDirector
{
    private readonly ITripBuilder _tripBuilder;

    public TripDirector(ITripBuilder builder)
    {
        _tripBuilder = builder;
    }

    /// <summary>
    /// Add companion to trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    public TripDto AddCompanionToTrip(TripDto tripDto)
    {
        _tripBuilder.SetCurrentTrip(tripDto);

        if (tripDto is { Companion: { } })
            _tripBuilder.AddCompanion(tripDto.Companion);

        return _tripBuilder.GetTrip();
    }

    /// <summary>
    /// Add driver to trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    public TripDto AddDriverToTrip(TripDto tripDto)
    {
        _tripBuilder.SetCurrentTrip(tripDto);

        if (tripDto is { Driver: { }, Car: { } })
            _tripBuilder.AddDriver(tripDto.Driver, tripDto.Car);

        return _tripBuilder.GetTrip();
    }

    /// <summary>
    /// Build full trip
    /// </summary>
    /// <param name="tripDto">Trip dto</param>
    /// <returns>Trip dto</returns>
    public TripDto BuildFullTrip(TripDto tripDto)
    {
        _tripBuilder.SetCurrentTrip(tripDto);

        if (tripDto is { Companion: { } })
            _tripBuilder.AddCompanion(tripDto.Companion);

        if (tripDto is { Driver: { }, Car: { } })
            _tripBuilder.AddDriver(tripDto.Driver, tripDto.Car);

        return _tripBuilder.GetTrip();
    }
}