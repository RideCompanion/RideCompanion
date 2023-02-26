using System.Text.Json;
using CarsModelsFromJson;

var carsModels = JsonSerializer.Deserialize<IList<CarModelDto>>(
    await File.ReadAllTextAsync("all-vehicles-model.json")
);

if (carsModels != null)
{
    var data = carsModels
        .Select(carModel => new CarModelEntity
        {
            Id = Guid.NewGuid(),
            Make = carModel.make,
            Model = carModel.model
        }).ToList();
    await using var db = new ApplicationContext();
    db.CarModels.AddRange(data);
    db.SaveChanges();
}