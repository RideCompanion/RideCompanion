/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using System.Globalization;
using System.Security.Claims;
using AutoMapper;
using Companion.App.Commands;
using Companion.Domain.Dto;
using Driver.App.Commands;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RideCompanion.Controllers.Base;
using Shared.Core.Extensions;
using User.App.Commands;
using User.App.Queries;
using User.Domain.Dto;
using User.Domain.Entities;

namespace RideCompanion.Controllers.Auth;

/// <summary>
/// Auth controller
/// </summary>
public class AuthController : BaseController
{
    private readonly ILogger<AuthController> _logger;
    private readonly IMapper _mapper;

    public AuthController(IMediator mediator, IMapper mapper, ILogger<AuthController> logger) : base(mediator, mapper)
    {
        _mapper = mapper;
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInDto dto)
    {
        if (dto.Email.IsNullOrEmpty() || dto.Password.IsNullOrEmpty())
            return (IActionResult)Results.BadRequest("Email or password is not set");

        var user = await Mediator.Send(new GetUserQuery(dto.Email, HasherExtension.HashString(dto.Password)));

        if (user is null)
            return (IActionResult)Results.Unauthorized();

        //var userClaims = await Mediator.Send(new GetClaimsQuery(user.Id));

        const string role = "Administrator";

        var claims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email!),
            new(ClaimTypes.MobilePhone, user.PhoneNumber!),
            new(ClaimTypes.Name, user.FullUserName!),
            new(ClaimTypes.DateOfBirth, user.DateOfBirth.ToString(CultureInfo.InvariantCulture)),
            //new("ClaimName", userClaims!.ClaimName!),
            new(ClaimTypes.Role, role),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties();

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);

        _logger.LogInformation("User {Email} logged in at {Time}.",
            user.Email, DateTime.UtcNow);

        return RedirectToAction("Index", "Home");
    }

    /// <summary>
    /// Sign Up
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    /// <summary>
    /// Sign Up
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpDto dto)
    {
        if (!ModelState.IsValid)
            return View(dto);
        
        if (dto.Email.IsNullOrEmpty() || dto.Password.IsNullOrEmpty())
            return (IActionResult)Results.BadRequest("Email or password is not set");
        
        var user = await Mediator.Send(new GetUserQuery(dto.Email!, HasherExtension.HashString(dto.Password!)));
        
        if(user != null)
            return View(dto);
        
        var newUser = await CreateUser(dto);
        var newCompanion = await CreateCompanion(dto);
        var newDriver = await CreateDriver(dto);

        dto.CompanionId = newCompanion;
        dto.DriverId = newDriver;
        newUser.Password = dto.Password;
        
        return RedirectToAction(nameof(SignIn), _mapper.Map<SignInDto>(newUser));
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    private async Task<AppUserEntity> CreateUser(SignUpDto dto)
    {
        return await Mediator.Send(new CreateUserCommand(dto));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    private async Task<Guid> CreateCompanion(SignUpDto dto)
    {
        var newCompanionDto = new CompanionDto
        {
            Id = default,
            FullName = dto.FullUserName,
            BirthDate = dto.DateOfBirth,
            PhoneNumber = dto.PhoneNumber,
        };
        
        return await Mediator.Send(new CreateCompanionCommand(newCompanionDto));
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    private async Task<Guid> CreateDriver(SignUpDto dto)
    {
        return await Mediator.Send(new CreateDriverCommand(dto.FullUserName, dto.DateOfBirth));
    }

    /// <summary>
    /// Log Out
    /// </summary>
    /// <returns></returns>
    [HttpPost]
    public async Task<RedirectToActionResult> LogOut()
    {
        var email = HttpContext.User.Identity!.Name;

        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);

        _logger.LogInformation("User {Email} logged in at {Time}.",
            email, DateTime.UtcNow);

        return RedirectToAction(nameof(SignIn));
    }
}