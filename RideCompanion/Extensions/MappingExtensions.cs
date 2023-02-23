/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Mapping;
using Driver.Domain.Mapping;
using Trip.Domain.Mapping;

namespace RideCompanion.Extensions;

/// <summary>
/// Mapping extensions
/// </summary>
public static class MappingExtensions
{
    /// <summary>
    /// AutoMapper extensions
    /// </summary>
    /// <param name="builder"> Builder </param>
    public static void AutoMapperExtensions(WebApplicationBuilder? builder)
    {
        builder?.Services.AddAutoMapper(typeof(TripMappingProfile));
        builder?.Services.AddAutoMapper(typeof(DriverMappingProfile));
        builder?.Services.AddAutoMapper(typeof(CompanionMappingProfile));
    }
}