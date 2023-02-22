using Companion.Domain.Dto;

namespace RideCompanion.ViewModels;

/// <summary>
/// Trip
/// </summary>
public class CompanionViewModel
{
    /// <summary>
    /// Companion
    /// </summary>
    public CompanionDto? CompanionDto { get; set; }
        
    /// <summary>
    /// Companion list
    /// </summary>
    public List<CompanionDto>? Companions { get; set; }
}