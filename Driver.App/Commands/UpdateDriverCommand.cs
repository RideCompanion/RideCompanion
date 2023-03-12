/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Update driver command
/// </summary>
public record UpdateDriverCommand(Guid DriverId, DriverDto? DriverDto) : IRequest<Guid>;

/// <summary>
/// Handler
/// </summary>
public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateDriverCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
    {
        var entity = _context.Drivers.FirstOrDefault(d => command.DriverDto != null && d.Id == command.DriverDto.Id);
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (entity == null)
            return command.DriverId;

        entity.FullName = command.DriverDto?.FullName;

        if (command.DriverDto != null)
            entity.BirthDate = command.DriverDto.BirthDate;

        entity.UpdateById = Guid.Parse(userId!);
        entity.UpdateDate = DateTime.Now;

        _context.Drivers.Update(entity);
        await _context.SaveChanges();
        return entity.Id;
    }
}