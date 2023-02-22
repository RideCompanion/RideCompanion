using Companion.Domain.Dto;
using Driver.Domain.Dto;
using Trip.Domain.Dto;
#pragma warning disable CS8618

namespace Trip.App.TripBuilder;

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

    public TripDto SetCurrentTrip(TripDto trip)
    {
        _trip = trip;
        return _trip;
    }

    public TripDto AddDriver(DriverDto driver, CarDto car)
    {
        _trip.Driver = driver;
        _trip.Car = car;
        return _trip;
    }

    public TripDto AddCompanion(CompanionDto companion)
    {
        _trip.Companion = companion;
        return _trip;
    }

    public TripDto GetTrip() => _trip;
}