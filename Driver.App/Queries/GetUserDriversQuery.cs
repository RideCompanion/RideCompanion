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
public record GetUserDriversQuery(
    Guid UserId
) : IRequest<IQueryable<DriverEntity>>;

public class GetDriverByUserIdQueryHandler : IRequestHandler<GetUserDriversQuery, IQueryable<DriverEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetDriverByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<DriverEntity>> Handle(GetUserDriversQuery query, CancellationToken cancellationToken)
    {
        var productList = _context.Drivers.Where(d => d.UserId == query.UserId);
        return Task.FromResult(productList);
    }
}