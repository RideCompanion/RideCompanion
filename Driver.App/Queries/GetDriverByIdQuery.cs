/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetDriverByIdQuery(
    Guid Id
) : IRequest<DriverEntity?>;

public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetDriverByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DriverEntity?> Handle(GetDriverByIdQuery query, CancellationToken cancellationToken)
    {
        var entity =
            await _context.Drivers.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken: cancellationToken);
        return entity;
    }
}