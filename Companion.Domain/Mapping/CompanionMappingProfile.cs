/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Companion.Domain.Dto;
using Companion.Domain.Entities;

namespace Companion.Domain.Mapping;

/// <summary>
/// Companion mapping profile
/// </summary>
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