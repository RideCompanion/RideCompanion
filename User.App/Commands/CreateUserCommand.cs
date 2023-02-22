using MediatR;
using Shared.Migrations;
using User.Domain.Dto;
using User.Domain.Entities;

namespace User.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateUserCommand : IRequest<AppUserEntity>
{
    private SignUpDto Dto { get; }
        
    public CreateUserCommand(SignUpDto dto)
    {
        Dto = dto;
    }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AppUserEntity>
    {
        private readonly IApplicationDbContext _context;
        
        public CreateUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<AppUserEntity> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            if (command.Dto is null)
                throw new Exception();
                
            var entity = new AppUserEntity
            {
                Id = default,
                    
                FullUserName = command.Dto.FullUserName,
                Password = command.Dto.Password,
                DateOfBirth = command.Dto.DateOfBirth,
                Email = command.Dto.Email,
                PhoneNumber = command.Dto.PhoneNumber,
                DriverId = command.Dto.DriverId,
                CompanionId = command.Dto.CompanionId,

                CreatedById = default,
                CreateDate = DateTime.Now,
                UpdateById = default,
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            var result = await _context.AppUsers.AddAsync(entity, cancellationToken);
            await _context.SaveChanges();
                
            return result.Entity;
        }
    }
}