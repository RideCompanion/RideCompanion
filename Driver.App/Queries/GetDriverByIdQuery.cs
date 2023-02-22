using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriverByIdQuery : IRequest<DriverEntity?>
{
    public Guid Id { get; set; }
    
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetDriverByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DriverEntity?> Handle(GetDriverByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _context.Drivers.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken: cancellationToken);
            return entity;
        }
    }
}