using System.Text.Json;
using CarsModelsFromJson;

var carsModels = JsonSerializer.Deserialize<IList<CarModelDto>>(
    await File.ReadAllTextAsync("all-vehicles-model.json")
);

await using var db = new ApplicationContext();

db.RemoveRange(db.CarModels);
db.RemoveRange(db.CarBrands);

if (carsModels != null)
{
    var data = carsModels
        .Select(carModel => new CarModelEntity
        {
            Id = Guid.NewGuid(),
            Brand = carModel.make,
            Model = carModel.model,
            CreatedById = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            CreateDate = DateTime.UtcNow,
            UpdateById = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpdateDate = DateTime.UtcNow,
            IsDeleted = false
        }).ToList();
    db.CarModels.AddRange(data);
    db.SaveChanges();
}

if (carsModels != null)
{
    var data = carsModels
        .Select(carModel => carModel.make)
        .Distinct()
        .Select(brand => new CarBrandEntity
        {
            Id = Guid.NewGuid(),
            Brand = brand,
            CreatedById = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            CreateDate = DateTime.UtcNow,
            UpdateById = Guid.Parse("00000000-0000-0000-0000-000000000000"),
            UpdateDate = DateTime.UtcNow,
            IsDeleted = false
        }).ToList();
    db.CarBrands.AddRange(data);
    db.SaveChanges();
}