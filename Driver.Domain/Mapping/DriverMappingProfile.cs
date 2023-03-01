/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Driver.Domain.Dto;
using Driver.Domain.Entities;

namespace Driver.Domain.Mapping;

/// <summary>
/// Driver mapping profile
/// </summary>
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
        
        CreateMap<CarModelEntity, CarModelDto>();
        CreateMap<CarModelDto, CarModelEntity>();
        
        CreateMap<CarBrandEntity, CarBrandDto>();
        CreateMap<CarBrandDto, CarBrandEntity>();
    }
}