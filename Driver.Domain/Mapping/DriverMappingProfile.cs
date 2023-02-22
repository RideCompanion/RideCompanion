using AutoMapper;
using Driver.Domain.Dto;
using Driver.Domain.Entities;

namespace Driver.Domain.Mapping;

public class DriverMappingProfile : Profile
{
    /// <summary>
    /// Driver mapping profile
    /// </summary>
    public DriverMappingProfile()
    {
        CreateMap<CarDto, CarEntity>();
        CreateMap<CarEntity, CarDto>();
        CreateMap<DriverDto, DriverEntity>();
        CreateMap<DriverEntity, DriverDto>();
    }
}