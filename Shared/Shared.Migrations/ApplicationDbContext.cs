using IdentityUser.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations.Relationships;

#pragma warning disable CS8618
#pragma warning disable CS0108, CS0114

namespace Shared.Migrations;

/// <summary>
/// Application db context
/// </summary>
public class ApplicationDbContext : IdentityDbContext<AppUserEntity, AppRoleEntity, Guid, AppUserClaimEntity, AppUserRoleEntity, AppUserLoginEntity, AppRoleClaimEntity, AppUserTokenEntity>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        RenameIdentityTables(modelBuilder);
        ConfigureRelationship.ConfigureRelationships(modelBuilder);
    }

    /// <summary>
    /// Save changes async
    /// </summary>
    /// <returns> Changed entities number </returns>
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    /// <summary>
    /// Rename default identity tables to custom names
    /// </summary>
    /// <param name="modelBuilder"> Model builder </param>
    private void RenameIdentityTables(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}