/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Trip.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetTripByIdQuery(Guid Id) : IRequest<TripEntity?>;

public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery, TripEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetTripByIdQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<TripEntity?> Handle(GetTripByIdQuery query, CancellationToken cancellationToken)
    {
        var data = await _context.Trips.FirstOrDefaultAsync(d => d.Id == query.Id,
            cancellationToken: cancellationToken);
        return data;
    }
}