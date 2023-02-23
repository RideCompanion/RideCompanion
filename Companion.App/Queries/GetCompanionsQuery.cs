/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Companion.App.Queries;

/// <summary>
/// Query
/// </summary>
public class GetCompanionsQuery : IRequest<IQueryable<CompanionEntity>>
{
    public class GetCompanionsQueryHandler : IRequestHandler<GetCompanionsQuery, IQueryable<CompanionEntity>>
    {
        private readonly IApplicationDbContext _context;

        public GetCompanionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public Task<IQueryable<CompanionEntity>> Handle(GetCompanionsQuery query, CancellationToken cancellationToken)
        {
            if (_context.Companions == null) 
                throw new Exception("Exception(1000): _context.Companions is null.");
                
            var entities = _context.Companions.Where(d => true);
                
            return Task.FromResult(entities);
        }
    }
}