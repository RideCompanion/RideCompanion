using Companion.App;
using Driver.App;
using Trip.App;
using User.App;

namespace RideCompanion.Extensions;

public static class MediatRConfigurationExtension
{
    public static Action<MediatRServiceConfiguration> Configuration()
    {
        return cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<CompanionApp>();
            cfg.RegisterServicesFromAssemblyContaining<DriverApp>();
            cfg.RegisterServicesFromAssemblyContaining<TripApp>();
            cfg.RegisterServicesFromAssemblyContaining<UserApp>();
        };
    }
}