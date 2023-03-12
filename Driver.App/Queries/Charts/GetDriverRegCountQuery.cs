/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using AutoMapper;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries.Charts;

/// <summary>
/// Get driver reg count query
/// </summary>
public record GetDriverRegCountQuery(DateTime dateFrom, DateTime dateTo) : IRequest<List<CarBrandDto>>;

/// <summary>
/// Handler
/// </summary>
public class GetCarMakersQueryHandler : IRequestHandler<GetDriverRegCountQuery, List<CarBrandDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCarMakersQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<CarBrandDto>> Handle(GetDriverRegCountQuery query, CancellationToken cancellationToken)
    {
        var entity = await _context.Drivers
            .Where(x => x.CreateDate.Date >= query.dateFrom.Date && x.CreateDate.Date <= query.dateTo.Date)
            .ToListAsync(cancellationToken);
        
        
        
        var result = _mapper.Map<List<CarBrandDto>>(entity);
        return result.Distinct().OrderBy(x => x.Brand).ToList();
    }
}