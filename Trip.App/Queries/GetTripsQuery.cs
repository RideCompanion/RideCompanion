/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Trip.App.Queries;

/// <summary>
/// Query
/// </summary>
public class GetTripsQuery : IRequest<IQueryable<TripEntity>>
{
    public class GetTripsQueryHandler : IRequestHandler<GetTripsQuery,IQueryable<TripEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetTripsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IQueryable<TripEntity>> Handle(GetTripsQuery query, CancellationToken cancellationToken)
        {
            var data = _context.Trips.Where(d => true);
            return Task.FromResult(data);
        }
    }
}