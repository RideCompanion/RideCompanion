/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RideCompanion.Controllers.Base;
using User.Domain.Entities;

namespace RideCompanion.Controllers.Auth;

/// <summary>
/// Auth controller
/// </summary>
public class AccountController : BaseController
{
    private readonly SignInManager<UserEntity> _signInManager;

    public AccountController(SignInManager<UserEntity> signInManager)
    {
        _signInManager = signInManager;
    }

    /// <summary>
    /// Google login
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="returnUrl"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public IActionResult GoogleLogin(string provider, string? returnUrl = null)
    {
        var redirectUrl = Url.Action(nameof(GoogleLoginCallback), "Account", new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
        return Challenge(properties, provider);
    }

    /// <summary>
    /// Google login callback
    /// </summary>
    /// <param name="returnUrl"></param>
    /// <param name="remoteError"></param>
    /// <returns></returns>
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GoogleLoginCallback(string? returnUrl = null, string? remoteError = null)
    {
        if (remoteError != null)
        {
            ModelState.AddModelError(string.Empty, $"Error from external provider: {remoteError}");
            return RedirectToAction("Index", "Home");
        }

        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
        {
            return RedirectToAction("Index", "Home");
        }

        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        if (result.Succeeded)
        {
            return LocalRedirect(returnUrl ?? "/");
        }
        if (result.IsLockedOut)
        {
            return RedirectToPage("Identity/Account/Login");
        }

        ViewData["ReturnUrl"] = returnUrl;
        ViewData["LoginProvider"] = info.LoginProvider;
        ViewData["Email"] = info.Principal.FindFirstValue(ClaimTypes.Email);
        
        return RedirectToAction("Index", "Home");
    }
}