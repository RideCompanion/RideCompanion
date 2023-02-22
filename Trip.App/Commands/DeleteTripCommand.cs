using MediatR;
using Shared.Migrations;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public class DeleteTripCommand : IRequest<Guid>
{
    public DeleteTripCommand(Guid id)
    {
        Id = id;
    }

    private Guid Id { get; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteTripCommandHandler : IRequestHandler<DeleteTripCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        
        public DeleteTripCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> Handle(DeleteTripCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Trips.FirstOrDefault(e => e.Id == command.Id);
            
            if (entity != null)
            {
                _context.Trips.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.Id;
        }
    }
}