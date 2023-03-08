/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Companion.App.Queries;

/// <summary>
/// Get companions by user id query
/// </summary>
public record GetCompanionsByUserIdQuery(Guid Id) : IRequest<IQueryable<CompanionEntity>>;

/// <summary>
/// Handler
/// </summary>
public class GetCompanionsByUserIdQueryHandler : IRequestHandler<GetCompanionsByUserIdQuery, IQueryable<CompanionEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCompanionsByUserIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public Task<IQueryable<CompanionEntity>> Handle(GetCompanionsByUserIdQuery query, CancellationToken cancellationToken)
    {
        var productList = _context.Companions.Where(d => d.UserId == query.Id);
        return Task.FromResult(productList);
    }
}