using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure;

public interface IIdentityDbContext : IDisposable
{
    DbSet<UserEntity> Users { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}