/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Command
/// </summary>
public class DeleteCarCommand : IRequest<Guid>
{
    public Guid CarId { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        
        public DeleteCarCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Cars.FirstOrDefault(e => e.Id == command.CarId);
            
            if (entity != null)
            {
                _context.Cars.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarId;
        }
    }
}