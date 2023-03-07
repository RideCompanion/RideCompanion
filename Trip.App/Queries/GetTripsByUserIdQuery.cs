/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Trip.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetTripsByUserIdQuery(Guid DriverId) : IRequest<IQueryable<CarEntity>>;

public class GetTripsByUserIdQueryHandler : IRequestHandler<GetTripsByUserIdQuery, IQueryable<CarEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetTripsByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<CarEntity>> Handle(GetTripsByUserIdQuery query, CancellationToken cancellationToken)
    {
        var data = _context.Cars.Where(d => d.DriverId == query.DriverId);
        return Task.FromResult(data);
    }
}