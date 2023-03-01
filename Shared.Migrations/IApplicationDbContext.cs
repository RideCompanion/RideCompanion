/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;
using User.Domain.Entities;

namespace Shared.Migrations;

public interface IApplicationDbContext
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
    
    Task<int> SaveChanges();
}