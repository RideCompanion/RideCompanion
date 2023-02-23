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
    
    DbSet<DriverEntity> Drivers { get; set; }
    DbSet<CarEntity> Cars { get; set; }
    DbSet<TripEntity> Trips { get; set; }
    DbSet<CompanionEntity> Companions { get; set; }
    
    Task<int> SaveChanges();
}