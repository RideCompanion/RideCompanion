/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

/// <summary>
/// Query
/// </summary>
public record GetCarModelsQuery : IRequest<IReadOnlyList<CarModelEntity>>;

public class GetCarModelsQueryHandler : IRequestHandler<GetCarModelsQuery, IReadOnlyList<CarModelEntity>>
{
    private readonly IApplicationDbContext _context;

    public GetCarModelsQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<CarModelEntity>> Handle(GetCarModelsQuery query, CancellationToken cancellationToken)
    {
        var entity = await _context.CarModels.ToListAsync(cancellationToken: cancellationToken);
        return entity;
    }
}