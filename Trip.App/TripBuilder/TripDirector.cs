using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

public class TripDirector : ITripDirector
{
    private readonly ITripBuilder _tripBuilder;

    public TripDirector(ITripBuilder builder)
    {
        _tripBuilder = builder;
    }

    public TripDto AddCompanionToTrip(TripDto trip)
    {
        _tripBuilder.SetCurrentTrip(trip);

        if (trip is { Companion: { } })
            _tripBuilder.AddCompanion(trip.Companion);

        return _tripBuilder.GetTrip();
    }

    public TripDto AddDriverToTrip(TripDto trip)
    {
        _tripBuilder.SetCurrentTrip(trip);

        if (trip is { Driver: { }, Car: { } })
            _tripBuilder.AddDriver(trip.Driver, trip.Car);

        return _tripBuilder.GetTrip();
    }

    public TripDto BuildFullTrip(TripDto trip)
    {
        _tripBuilder.SetCurrentTrip(trip);

        if (trip is { Companion: { } })
            _tripBuilder.AddCompanion(trip.Companion);

        if (trip is { Driver: { }, Car: { } })
            _tripBuilder.AddDriver(trip.Driver, trip.Car);

        return _tripBuilder.GetTrip();
    }
}