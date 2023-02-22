using AutoMapper;
using Trip.Domain.Dto;
using Trip.Domain.Entities;

namespace Trip.Domain.Mapping;

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