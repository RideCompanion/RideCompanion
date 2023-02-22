using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetCarByIdQuery : IRequest<CarEntity?>
{
    public Guid Id { get; set; }
    
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetCarByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CarEntity?> Handle(GetCarByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _context.Cars.FirstOrDefaultAsync(d => d.Id == query.Id, cancellationToken: cancellationToken);
            return entity;
        }
    }
}