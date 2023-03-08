/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Shared.Migrations;
using Companion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Companion.App.Queries;

/// <summary>
/// Get companion by id query
/// </summary>
public record GetCompanionByIdQuery(Guid Id) : IRequest<CompanionEntity?>;

/// <summary>
/// Handler
/// </summary>
public class GetCompanionByIdQueryHandler : IRequestHandler<GetCompanionByIdQuery, CompanionEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetCompanionByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CompanionEntity?> Handle(GetCompanionByIdQuery query, CancellationToken cancellationToken)
    {
        var data = await _context.Companions.FirstOrDefaultAsync(d => d.Id == query.Id);
        return data;
    }
}