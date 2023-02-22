using System.Security.Claims;
using AutoMapper;
using Companion.Domain.Dto;
using Companion.Domain.Entities;
using Driver.Domain.Dto;
using Driver.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;
using Trip.Domain.Dto;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public class UpdateTripCommand : IRequest<Guid>
{
    public UpdateTripCommand(TripDto viewModelTripDto)
    {
        TripDto = viewModelTripDto;
    }

    public TripDto TripDto { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        
        public UpdateTripCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        
        public async Task<Guid> Handle(UpdateTripCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Trips.FirstOrDefault(e => e.Id == command.TripDto.Id);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (entity == null) 
                return command.TripDto.Id;

            entity.Driver = command.TripDto.Driver != null
                ? _mapper.Map<DriverDto, DriverEntity>(command.TripDto.Driver)
                : null;
            entity.Companion = command.TripDto.Companion != null
                ? _mapper.Map<CompanionDto, CompanionEntity>(command.TripDto.Companion)
                : null;
            entity.Car = command.TripDto.Car != null 
                ? _mapper.Map<CarDto, CarEntity>(command.TripDto.Car) 
                : null;
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
}