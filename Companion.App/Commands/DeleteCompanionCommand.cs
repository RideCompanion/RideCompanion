using MediatR;
using Shared.Migrations;

namespace Companion.App.Commands;

/// <summary>
/// Command
/// </summary>
public class DeleteCompanionCommand : IRequest<Guid>
{
    public DeleteCompanionCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteCompanionCommandHandler : IRequestHandler<DeleteCompanionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        
        public DeleteCompanionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> Handle(DeleteCompanionCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Companions.FirstOrDefault(e => e.Id == command.Id);
            
            if (entity != null)
            {
                _context.Companions.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.Id;
        }
    }
}