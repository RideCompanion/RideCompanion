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
public class DeleteDriverCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public DeleteDriverCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<Guid> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Drivers.FirstOrDefault(e => e.Id == command.DriverId);
            
            if (entity != null)
            {
                _context.Drivers.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.DriverId;
        }
    }
}