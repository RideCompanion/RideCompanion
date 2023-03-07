/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;
using Trip.Domain.Dto;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public record UpdateTripCommand(TripDto TripDto) : IRequest<Guid>;

public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UpdateTripCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<Guid> Handle(UpdateTripCommand command, CancellationToken cancellationToken)
    {
        var entity = _context.Trips.FirstOrDefault(e => e.Id == command.TripDto.Id);
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (entity == null)
            return command.TripDto.Id;

        entity.DriverId = command.TripDto.Driver.Id;
        entity.CompanionId = command.TripDto.Companion.Id;
        entity.CarId = command.TripDto.Car.Id;
        entity.AddressFrom = command.TripDto.AddressFrom;
        entity.AddressTo = command.TripDto.AddressTo;
        entity.DateTime = command.TripDto.DateTime;

        entity.UpdateById = Guid.Parse(userId!);
        entity.UpdateDate = DateTime.Now;
        entity.IsDeleted = command.TripDto.IsDeleted;

        _context.Trips.Update(entity);
        await _context.SaveChanges();
        return entity.Id;
    }
}