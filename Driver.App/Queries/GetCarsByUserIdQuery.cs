/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Get cars by user id query
/// </summary>
public record GetCarsByUserIdQuery(Guid UserId) : IRequest<IQueryable<CarEntity>>;

/// <summary>
/// Handler
/// </summary>
public class GetCarsByUserIdQueryHandler : IRequestHandler<GetCarsByUserIdQuery, IQueryable<CarEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCarsByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<CarEntity>> Handle(GetCarsByUserIdQuery query, CancellationToken cancellationToken)
    {
        var entity = _context.Cars.Where(d => d.UserId == query.UserId);
        return Task.FromResult(entity);
    }
}