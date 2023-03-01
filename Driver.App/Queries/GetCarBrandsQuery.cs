/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetCarBrandsQuery : IRequest<List<CarBrandDto>>;

public class GetCarMakersQueryHandler : IRequestHandler<GetCarBrandsQuery, List<CarBrandDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarMakersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CarBrandDto>> Handle(GetCarBrandsQuery query, CancellationToken cancellationToken)
    {
        var entity = await _context.CarBrands.ToListAsync(cancellationToken);
        var result = _mapper.Map<List<CarBrandDto>>(entity);
        return result.Distinct().OrderBy(x => x.Brand).ToList();
    }
}