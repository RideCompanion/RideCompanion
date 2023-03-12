/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Get drivers query
/// </summary>
public record GetDriversQuery : IRequest<IQueryable<DriverEntity>>;

/// <summary>
/// Handler
/// </summary>
public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, IQueryable<DriverEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetDriversQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<DriverEntity>> Handle(GetDriversQuery query, CancellationToken cancellationToken)
    {
        var entity = _context.Drivers.Where(d => true);
        return Task.FromResult(entity);
    }
}