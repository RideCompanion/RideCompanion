using AutoMapper;
using Companion.Domain.Dto;
using Companion.Domain.Entities;

namespace Companion.Domain.Mapping;

public class CompanionMappingProfile : Profile
{
    /// <summary>
    /// Companion mapping profile
    /// </summary>
    public CompanionMappingProfile()
    {
        CreateMap<CompanionDto, CompanionEntity>();
        CreateMap<CompanionEntity, CompanionDto>();
    }
}