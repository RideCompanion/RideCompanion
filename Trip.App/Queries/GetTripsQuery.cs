using MediatR;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Trip.App.Queries;

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