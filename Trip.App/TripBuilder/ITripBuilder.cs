using Companion.Domain.Dto;
using Driver.Domain.Dto;
using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

public interface ITripBuilder
{
    TripDto SetCurrentTrip(TripDto trip);
    TripDto AddDriver(DriverDto driver, CarDto car);
    TripDto AddCompanion(CompanionDto companion);
    TripDto GetTrip();
}