/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetCarsByDriverIdQuery(
    Guid DriverId
) : IRequest<IQueryable<CarEntity>>;

public class GetCarsByDriverIdQueryHandler : IRequestHandler<GetCarsByDriverIdQuery, IQueryable<CarEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCarsByDriverIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<CarEntity>> Handle(GetCarsByDriverIdQuery query, CancellationToken cancellationToken)
    {
        var productList = _context.Cars.Where(d => d.DriverId == query.DriverId);
        return Task.FromResult(productList);
    }
}