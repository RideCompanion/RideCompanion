/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using User.Domain.Entities;

namespace User.App.Queries;

/// <summary>
/// Query
/// </summary>
public class GetClaimsQuery : IRequest<ClaimEntity?>
{
    private readonly Guid _userId;
        
    public GetClaimsQuery(Guid userId)
    {
        _userId = userId;
    }

    public class GetUserCommandHandler : IRequestHandler<GetClaimsQuery, ClaimEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ClaimEntity?> Handle(GetClaimsQuery query, CancellationToken cancellationToken)
        {
            var userClaims = await _context.UsersClaims.FirstOrDefaultAsync(d =>
                    d.UserId == query._userId,
                cancellationToken: cancellationToken);

            if (userClaims is null)
            {
                return null;
            }
                
            var data = await _context.Claims.FirstOrDefaultAsync(d =>
                    d.Id == userClaims.ClaimId,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}