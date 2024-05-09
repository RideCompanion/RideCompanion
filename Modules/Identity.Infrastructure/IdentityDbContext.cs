using Identity.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure;

public class IdentityDbContext : DbContext, IIdentityDbContext
{
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>().HasKey(x => x.Id);

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                CreatedBy = Guid.Empty,
                LastModified = null,
                LastModifiedBy = null,
                FirstName = "Admin",
                LastName = "System",
                Username = "admin",
                Password = "admin",
                IsActive = true
            });

        modelBuilder.Entity<UserEntity>().HasData(
            new UserEntity
            {
                Id = Guid.NewGuid(),
                Created = DateTime.Now,
                CreatedBy = Guid.Empty,
                LastModified = null,
                LastModifiedBy = null,
                FirstName = "Manager",
                LastName = "System",
                Username = "manager",
                Password = "manager",
                IsActive = true
            }
        );
    }

}