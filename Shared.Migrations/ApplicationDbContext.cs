/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;
using User.Domain.Entities;
#pragma warning disable CS0108, CS0114, CS8618

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext<UserEntity, RoleEntity, Guid>, IApplicationDbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<UserClaimEntity> UserClaims { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserRolesEntity> UserRoles { get; set; }
    
    public DbSet<DriverEntity> Drivers { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<CarModelEntity> CarModels { get; set; }
    public DbSet<CarBrandEntity> CarBrands { get; set; }
    public DbSet<TripEntity> Trips { get; set; }
    public DbSet<CompanionEntity> Companions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        RenameIdentityTables(builder);
        
        // One driver - many cars
        builder.Entity<CarEntity>()
            .HasOne<DriverEntity>(s => s.Driver)
            .WithMany(g => g.Cars)
            .HasForeignKey(s => s.DriverId);
    }

    private void RenameIdentityTables(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.HasDefaultSchema("public");
        
        builder.Entity<UserEntity>(entity =>
        {
            entity.ToTable(name: "Users");
        });
        
        builder.Entity<RoleEntity>(entity =>
        {
            entity.ToTable(name: "Roles");
        });
        
        builder.Entity<UserRolesEntity>(entity =>
        {
            entity.ToTable("UserRoles");
        });
        
        builder.Entity<UserClaimEntity>(entity =>
        {
            entity.ToTable("UserClaims");
        });
        
        builder.Entity<IdentityUserLogin<Guid>>(entity =>
        {
            entity.ToTable("UserLogins");
        });
        
        builder.Entity<IdentityRoleClaim<Guid>>(entity =>
        {
            entity.ToTable("RoleClaims");
        });
        
        builder.Entity<IdentityUserToken<Guid>>(entity =>
        {
            entity.ToTable("UserTokens");
        });
    }

    public new async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}