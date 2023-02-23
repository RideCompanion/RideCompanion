/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using FastReport.Web;

namespace RideCompanion.Models;

/// <summary>
/// Home model
/// </summary>
public class HomeModel
{
    /// <summary>
    /// Web report
    /// </summary>
    public WebReport? WebReport { get; set; }
    
    /// <summary>
    /// Reports list
    /// </summary>
    public string[]? ReportsList { get; set; }
}