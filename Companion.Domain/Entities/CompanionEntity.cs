using Shared.Core.Entities;

namespace Companion.Domain.Entities;

/// <summary>
/// Companion
/// </summary>
public class CompanionEntity : BaseEntity
{
    /// <summary>
    /// Full name
    /// </summary>
    public string? FullName { get; set; }
    
    /// <summary>
    /// Birth date
    /// </summary>
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }
}