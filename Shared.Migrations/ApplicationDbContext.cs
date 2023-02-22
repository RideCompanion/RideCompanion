using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;
using User.Domain.Entities;

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public DbSet<AppUserEntity> AppUsers { get; set; }
    public DbSet<AppUserClaimEntity> UsersClaims { get; set; }
    public DbSet<ClaimEntity> Claims { get; set; }
    public DbSet<AppRoleEntity> AppRoles { get; set; }
    public DbSet<ClaimEntity> AppUserRoleEntity { get; set; }

    public DbSet<DriverEntity> Drivers { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<TripEntity> Trips { get; set; }
    public DbSet<CompanionEntity> Companions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}