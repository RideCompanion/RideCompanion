namespace CarsModelsFromJson;

/// <summary>
/// Car model entity
/// </summary>
public class CarModelEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Make
    /// </summary>
    public string Make { get; set; }

    /// <summary>
    /// Model
    /// </summary>
    public string Model { get; set; }
}