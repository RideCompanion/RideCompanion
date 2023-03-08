using Microsoft.EntityFrameworkCore;

namespace CarsModelsFromJson;

public sealed class ApplicationContext : DbContext
{
    public DbSet<CarModelEntity> CarModels { get; set; } = null!;
    public DbSet<CarBrandEntity> CarBrands { get; set; } = null!;
 
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}