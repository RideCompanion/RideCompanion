/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Trip.Domain.Dto;
using Trip.Domain.Entities;

namespace Trip.Domain.Mapping;

/// <summary>
/// Trip mapping profile
/// </summary>
public class TripMappingProfile : Profile
{
    /// <summary>
    /// Trip mapping profile
    /// </summary>
    public TripMappingProfile()
    {
        CreateMap<TripDto, TripEntity>();
        CreateMap<TripEntity, TripDto>();
    }
}