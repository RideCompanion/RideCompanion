using Microsoft.EntityFrameworkCore;

namespace CarsModelsFromJson;

public class ApplicationContext : DbContext
{
    public DbSet<CarModelEntity> CarModels { get; set; } = null!;
    public DbSet<CarBrandEntity> CarBrands { get; set; } = null!;
 
    public ApplicationContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Username=postgres;Password=1123581321;Host=localhost;Port=5432;Database=RideCompanionDb;IntegratedSecurity=True;Pooling=True;");
    }
}