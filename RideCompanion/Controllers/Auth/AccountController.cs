/*
 * Date: 2023-03-23
 * Author: A.A.Konkin
*/

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Google;
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
    private readonly UserManager<UserEntity> _userManager;

    public AccountController(SignInManager<UserEntity> signInManager, UserManager<UserEntity> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    /// <summary>
    /// Sign in with Google
    /// </summary>
    /// <param name="returnUrl"> Return URL </param>
    /// <returns> Sign in with Google </returns>
    public IActionResult SignInWithGoogle(string returnUrl = "/")
    {
        var redirectUrl = Url.Action(nameof(SignInWithGoogleCallback), "Account", new { returnUrl });
        var properties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme, redirectUrl);
        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Sign in with Google callback
    /// </summary>
    /// <param name="returnUrl"> Return URL </param>
    /// <returns> Sign in with Google </returns>
    public async Task<IActionResult> SignInWithGoogleCallback(string returnUrl = "/")
    {
        var info = await _signInManager.GetExternalLoginInfoAsync();
        if (info == null)
            return RedirectToAction(nameof(SignInWithGoogle));

        var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor: true);
        if (result.Succeeded)
            return LocalRedirect(returnUrl);

        var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        var user = new UserEntity { UserName = email, Email = email };
        var createUserResult = await _userManager.CreateAsync(user);

        if (!createUserResult.Succeeded)
            return
                RedirectToAction(nameof(SignInWithGoogle));

        var addLoginResult = await _userManager.AddLoginAsync(user, info);

        if (!addLoginResult.Succeeded)
            return RedirectToAction(nameof(SignInWithGoogle));

        await _signInManager.SignInAsync(user, isPersistent: false);
        return LocalRedirect(returnUrl);
    }

    /// <summary>
    /// Logout
    /// </summary>
    /// <returns> Redirect to sign in </returns>
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction(nameof(SignInWithGoogle));
    }
}