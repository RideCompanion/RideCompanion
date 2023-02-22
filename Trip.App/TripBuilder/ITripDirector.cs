using Trip.Domain.Dto;

namespace Trip.App.TripBuilder;

public interface ITripDirector
{
    TripDto AddCompanionToTrip(TripDto trip);
    TripDto AddDriverToTrip(TripDto trip);
    TripDto BuildFullTrip(TripDto trip);
}