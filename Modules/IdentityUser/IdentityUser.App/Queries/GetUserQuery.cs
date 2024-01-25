using IdentityUser.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace IdentityUser.App.Queries;

public record GetUserQuery(
    string Email,
    string Password
) : IRequest<AppUserEntity?>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, AppUserEntity?>
{
    private readonly IApplicationDbContext _context;

    public GetUserQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AppUserEntity?> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var data = await _context.Users.FirstOrDefaultAsync(d =>
                d.Email == query.Email,
            cancellationToken: cancellationToken);

        return data;
    }
}