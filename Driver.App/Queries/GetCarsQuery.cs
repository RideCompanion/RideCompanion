/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Get cars query
/// </summary>
public record GetCarsQuery : IRequest<IQueryable<CarEntity>>;

/// <summary>
/// Handler
/// </summary>
public class GetCarsQueryHandler : IRequestHandler<GetCarsQuery, IQueryable<CarEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCarsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<CarEntity>> Handle(GetCarsQuery query, CancellationToken cancellationToken)
    {
        var entity = _context.Cars.Where(d => true);
        return Task.FromResult(entity);
    }
}