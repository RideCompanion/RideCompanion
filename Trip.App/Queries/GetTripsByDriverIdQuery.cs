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
public class GetTripsByDriverIdQuery : IRequest<IQueryable<TripEntity>>
{
    public Guid DriverId { get; set; }
    
    public class GetTripsByDriverIdQueryHandler : IRequestHandler<GetTripsByDriverIdQuery,IQueryable<TripEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetTripsByDriverIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public Task<IQueryable<TripEntity>> Handle(GetTripsByDriverIdQuery query, CancellationToken cancellationToken)
        {
            var data = _context.Trips.Where(d => d.DriverId == query.DriverId);
            return Task.FromResult(data);
        }
    }
}