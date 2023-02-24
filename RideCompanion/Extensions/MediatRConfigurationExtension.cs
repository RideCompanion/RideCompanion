/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.App;
using Driver.App;
using Trip.App;
using User.App;

namespace RideCompanion.Extensions;

/// <summary>
/// MediatR configuration extension
/// </summary>
public static class MediatRConfigurationExtension
{
    /// <summary>
    /// Configuration application services
    /// </summary>
    /// <returns></returns>
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