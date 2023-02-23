/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

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
using Trip.Domain.Entities;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateTripCommand : IRequest<Guid>
{
    public CreateTripCommand(TripDto tripDto)
    {
        TripDto = tripDto;
    }

    private TripDto TripDto { get; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        
        public CreateTripCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }
        
        public async Task<Guid> Handle(CreateTripCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new TripEntity
            {
                Id = default,
                
                Driver = command.TripDto.Driver != null ? _mapper.Map<DriverDto, DriverEntity>(command.TripDto.Driver) : null,
                Companion = command.TripDto.Companion != null ? _mapper.Map<CompanionDto, CompanionEntity>(command.TripDto.Companion) : null,
                Car = command.TripDto.Car != null ? _mapper.Map<CarDto, CarEntity>(command.TripDto.Car) : null,
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
}