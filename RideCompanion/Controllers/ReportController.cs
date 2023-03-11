using Microsoft.AspNetCore.Mvc;

namespace RideCompanion.Controllers;

/// <summary>
/// Report Controller
/// </summary>
public class ReportController : Controller
{
    /// <summary>
    /// Reoprt Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }
}