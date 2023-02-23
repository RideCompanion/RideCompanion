/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace RideCompanion.Models;

/// <summary>
/// Error view model
/// </summary>
public class ErrorViewModel
{
    /// <summary>
    /// Request id
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// Show request id or not
    /// </summary>
    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}