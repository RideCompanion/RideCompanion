/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;
using Trip.Domain.Dto;
using Trip.Domain.Entities;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public record CreateTripCommand(TripDto TripDto) : IRequest<Guid>;

public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CreateTripCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(CreateTripCommand command, CancellationToken cancellationToken)
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        var entity = new TripEntity
        {
            Id = default,

            DriverId = command.TripDto.DriverId,
            CompanionId = command.TripDto.CompanionId,
            CarId = command.TripDto.CarId,
            AddressFrom = command.TripDto.AddressFrom,
            AddressTo = command.TripDto.AddressTo,
            DateTime = command.TripDto.DateTime,

            CreatedById = Guid.Parse(userId!),
            CreateDate = DateTime.Now,
            UpdateById = Guid.Parse(userId!),
            UpdateDate = DateTime.Now,
            IsDeleted = false
        };

        _context.Trips?.Add(entity);
        await _context.SaveChanges();
        return entity.Id;
    }
}