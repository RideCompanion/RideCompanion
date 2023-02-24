/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;
using User.Domain.Entities;

namespace User.App.Queries
{
    /// <summary>
    /// Query
    /// </summary>
    public record GetUserQuery(string Email, string Password) : IRequest<UserEntity?>;

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetUserQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.Users.FirstOrDefaultAsync(d =>
                    d.Email == query.Email
                    && d.Password == query.Password,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}