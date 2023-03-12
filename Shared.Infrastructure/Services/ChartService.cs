using Driver.App.Queries.Charts;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Infrastructure.Services.Interfaces;

namespace Shared.Infrastructure.Services;

/// <summary>
/// Chart service
/// </summary>
public class ChartService : IChartService
{
    private readonly IMediator _mediator;
    private readonly ILogger<ChartService> _logger;
        
    public ChartService(IMediator mediator, ILogger<ChartService> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }
    
    /// <summary>
    /// Get driver companion chart dto
    /// </summary>
    /// <param name="dateFrom"> Date from </param>
    /// <param name="dateTo"> Date to </param>
    /// <returns> Driver companion chart DTO </returns>
    public async Task<DriverCompanionChartDto> GetDriverCompanionChartDto(DateTime dateFrom, DateTime dateTo)
    {
        var data1 = await _mediator.Send(new GetDriverRegCountQuery(dateFrom, dateTo));
        
        var data = new DriverCompanionChartDto
        {
            DriverSeries = new int[]
            {
            },
            CompanionSeries = new int[]
            {
            },
            Dates = new DateOnly[]
            {
            }
        };
        
        return new DriverCompanionChartDto();
    }
}