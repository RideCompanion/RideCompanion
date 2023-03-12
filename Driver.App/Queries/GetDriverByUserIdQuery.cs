/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Get driver by user id query
/// </summary>
public record GetDriverByUserIdQuery(Guid UserId) : IRequest<IQueryable<DriverEntity>>;

/// <summary>
/// Handler
/// </summary>
public class GetDriverByUserIdQueryHandler : IRequestHandler<GetDriverByUserIdQuery, IQueryable<DriverEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetDriverByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<DriverEntity>> Handle(GetDriverByUserIdQuery query, CancellationToken cancellationToken)
    {
        var entity = _context.Drivers.Where(d => d.UserId == query.UserId);
        return Task.FromResult(entity);
    }
}