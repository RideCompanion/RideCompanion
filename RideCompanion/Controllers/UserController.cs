/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;

namespace RideCompanion.Controllers;

/// <summary>
/// User controller
/// </summary>
public class UserController : BaseController
{
    /// <summary>
    /// Index
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
    {
        return View();
    }

    
}