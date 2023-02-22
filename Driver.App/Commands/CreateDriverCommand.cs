using System.Security.Claims;
using Driver.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateDriverCommand : IRequest<Guid>
{
    private string? FullName { get; }
    private DateTime BirthDate { get; }

    public CreateDriverCommand(string? fullName, DateTime birthDate)
    {
        FullName = fullName;
        BirthDate = birthDate;
    }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateDriverCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new DriverEntity
            {
                Id = default,
                UserId = userId,
                FullName = command.FullName,
                BirthDate = command.BirthDate,
                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            _context.Drivers.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}