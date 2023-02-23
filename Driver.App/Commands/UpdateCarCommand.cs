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
/// Command
/// </summary>
public class UpdateCarCommand : IRequest<Guid>
{
    private CarDto CarDto { get; set; }

    public UpdateCarCommand(CarDto carDto)
    {
        CarDto = carDto;
    }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UpdateCarCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Cars.FirstOrDefault(e => e.Id == command.CarDto.Id);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (entity != null)
            {
                entity.DriverId = command.CarDto.DriverId;
                entity.Number = command.CarDto.Number;
                entity.Color = command.CarDto.Color;
                entity.Model = command.CarDto.Model;
                entity.UpdateById = Guid.Parse(userId!);
                entity.UpdateDate = DateTime.Now;

                _context.Cars.Update(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarDto.Id;
        }
    }
}