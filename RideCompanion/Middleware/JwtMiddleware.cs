using Identity.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace RideCompanion.Middleware;

/// <summary>
///
/// </summary>
/// <param name="next"></param>
/// <param name="appSettings"></param>
public class JwtMiddleware(
    RequestDelegate next,
    IOptions<AppSettings> appSettings
)
{
    private readonly AppSettings _appSettings = appSettings.Value;

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userService"></param>
    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            await AttachUserToContext(context, userService, token);

        await next(context);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="context"></param>
    /// <param name="userService"></param>
    /// <param name="token"></param>
    private async Task AttachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clock skew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            //Attach user to context on successful JWT validation
            context.Items["User"] = await userService.GetById(userId);
        }
        catch
        {
            //Do nothing if JWT validation fails
            // user is not attached to context so the request won't have access to secure routes
        }
    }
}