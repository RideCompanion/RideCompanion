/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Companion.Domain.Dto;

namespace RideCompanion.ViewModels;

/// <summary>
/// Trip view model
/// </summary>
public class CompanionViewModel
{
    /// <summary>
    /// Companion dto
    /// </summary>
    public CompanionDto? CompanionDto { get; set; }
        
    /// <summary>
    /// Companion list
    /// </summary>
    public List<CompanionDto>? Companions { get; set; }
}