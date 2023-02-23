/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Query
/// </summary>
public class GetDriverByUserIdQuery : IRequest<IQueryable<DriverEntity>>
{
    public Guid UserId { get; set; }

    public GetDriverByUserIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public class GetDriverByUserIdQueryHandler : IRequestHandler<GetDriverByUserIdQuery, IQueryable<DriverEntity>>
    {
        private readonly IApplicationDbContext _context;

        public GetDriverByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<DriverEntity>> Handle(GetDriverByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Drivers.Where(d => d.UserId == query.UserId);
            return Task.FromResult(productList);
        }
    }
}