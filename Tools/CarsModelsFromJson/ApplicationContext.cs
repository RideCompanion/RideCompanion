using Microsoft.EntityFrameworkCore;

namespace CarsModelsFromJson;

public class ApplicationContext : DbContext
{
    public DbSet<CarModelEntity> CarModels { get; set; } = null!;
 
    public ApplicationContext()
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=пароль_от_postgres");
    }
}