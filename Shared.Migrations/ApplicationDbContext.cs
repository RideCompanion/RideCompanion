/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;
using User.Domain.Entities;

#pragma warning disable CS8618

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public new DbSet<UserEntity> Users { get; set; }
    public DbSet<UserClaimEntity> UsersClaims { get; set; }
    public DbSet<ClaimEntity> Claims { get; set; }
    public new DbSet<RoleEntity> Roles { get; set; }
    public new DbSet<UserRoleEntity> UserRoles { get; set; }

    public DbSet<DriverEntity> Drivers { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<TripEntity> Trips { get; set; }
    public DbSet<CompanionEntity> Companions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Many users - many claims
        modelBuilder.Entity<UserClaimEntity>().HasKey(sc => new { sc.UserId, sc.ClaimId });
        
        // Many users - many roles
        modelBuilder.Entity<UserRoleEntity>().HasKey(sc => new { sc.UserId, sc.RoleId });
        
        // One driver - many cars
        modelBuilder.Entity<CarEntity>()
            .HasOne<DriverEntity>(s => s.Driver)
            .WithMany(g => g.Cars)
            .HasForeignKey(s => s.DriverId);
    }

    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}