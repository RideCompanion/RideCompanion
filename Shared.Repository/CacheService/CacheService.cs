using Driver.App.Queries;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Shared.Repository.CacheService;

public class CacheService
{
    private readonly IMemoryCache _cache;
    private readonly IMediator _mediator;
    private readonly ILogger<CacheService> _logger;

    public CacheService(IMemoryCache cache, IMediator mediator, ILogger<CacheService> logger)
    {
        _cache = cache;
        _mediator = mediator;
        _logger = logger;
    }

    public async Task<IReadOnlyList<CarBrandDto>?> GetCarBrandsFromCache()
    {
        _cache.TryGetValue("CarBrands", out IReadOnlyList<CarBrandDto>? carModels);

        if (carModels is null)
        {
            var data = await _mediator.Send(new GetCarBrandsQuery());
            _logger.LogDebug("Set CarModels from cache.");
            _cache.Set("CarBrands", data,
                new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
            return data;
        }

        _logger.LogDebug("Get CarModels from cache.");

        return carModels;
    }
}