/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;
using System.Security.Claims;
using Driver.Domain.Dto;

namespace Driver.App.Commands;

/// <summary>
/// Create car command
/// </summary>
public record CreateCarCommand(Guid DriverId, CarDto CarDto) : IRequest<Guid>;

/// <summary>
/// Handler
/// </summary>
public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateCarCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(CreateCarCommand command, CancellationToken cancellationToken)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var entity = new CarEntity
        {
            Id = default,

            DriverId = command.DriverId,
            UserId = Guid.Parse(userId!),
            Number = command.CarDto.Number,
            Color = command.CarDto.Color,
            Brand = command.CarDto.Brand,
            Model = command.CarDto.Model,

            CreatedById = Guid.Parse(userId!),
            CreateDate = DateTime.Now,
            UpdateById = Guid.Parse(userId!),
            UpdateDate = DateTime.Now,
            IsDeleted = false
        };

        _context.Cars.Add(entity);
        await _context.SaveChanges();
        return entity.Id;
    }
}