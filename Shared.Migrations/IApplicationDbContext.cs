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
    DbSet<AppUserEntity> AppUsers { get; set; }
    DbSet<AppUserClaimEntity> UsersClaims { get; set; }
    DbSet<ClaimEntity> Claims { get; set; }
    DbSet<AppRoleEntity> AppRoles { get; set; }
    DbSet<ClaimEntity> AppUserRoleEntity { get; set; }
        
        
    DbSet<DriverEntity> Drivers { get; set; }
    DbSet<CarEntity> Cars { get; set; }
    DbSet<TripEntity> Trips { get; set; }
    DbSet<CompanionEntity> Companions { get; set; }
    
    Task<int> SaveChanges();
}