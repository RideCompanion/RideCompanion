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
/// Get car by id query
/// </summary>
public record GetCarByIdQuery(Guid Id) : IRequest<CarEntity?>;

/// <summary>
/// Handler
/// </summary>
public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetCarByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CarEntity?> Handle(GetCarByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _context.Cars.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken: cancellationToken);
        return result;
    }
}