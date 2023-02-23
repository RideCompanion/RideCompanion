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
public class GetUserQuery : IRequest<AppUserEntity?>
{
    private readonly string? _email;
    private readonly string? _password;
        
    public GetUserQuery(string email, string password)
    {
        _email = email;
        _password = password;
    }

    public class GetUserCommandHandler : IRequestHandler<GetUserQuery, AppUserEntity?>
    {
        private readonly IApplicationDbContext _context;

        public GetUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUserEntity?> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var data = await _context.AppUsers.FirstOrDefaultAsync(d =>
                    d.Email == query._email
                    && d.Password == query._password,
                cancellationToken: cancellationToken);

            return data;
        }
    }
}