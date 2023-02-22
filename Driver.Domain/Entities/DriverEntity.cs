using Shared.Core.Entities;

namespace Driver.Domain.Entities;

/// <summary>
/// Driver
/// </summary>
public class DriverEntity : BaseEntity
{
    /// <summary>
    /// User
    /// </summary>
    public string? UserId { get; init; }
    
    /// <summary>
    /// Full name
    /// </summary>
    public string? FullName { get; set; }
    
    /// <summary>
    /// Birth date
    /// </summary>
    public DateTime BirthDate { get; set; }
}