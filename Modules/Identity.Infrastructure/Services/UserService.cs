using Identity.Domain.Entities;
using Identity.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Core;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Identity.Infrastructure.Services;

public class UserService(
    IOptions<AppSettings> appSettings,
    IIdentityDbContext db
) : IUserService
{
    private readonly AppSettings _appSettings = appSettings.Value;

    /// <summary>
    ///
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await db.Users.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = await GenerateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    public async Task<IEnumerable<UserEntity>> GetAll()
    {
        return await db
            .Users
            .Where(x => x.IsActive == true)
            .ToListAsync();
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserEntity?> GetById(Guid id)
    {
        return await db.Users.FirstOrDefaultAsync(x => x.Id == id);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
    public async Task<UserEntity?> AddAndUpdateUser(UserEntity userObj)
    {
        bool isSuccess = false;

        if (userObj.Id != Guid.Empty || userObj.Id != default)
        {
            var obj = await db.Users.FirstOrDefaultAsync(c => c.Id == userObj.Id);

            if (obj != null)
            {
                // obj.Address = userObj.Address;
                obj.FirstName = userObj.FirstName;
                obj.LastName = userObj.LastName;
                db.Users.Update(obj);
                isSuccess = await db.SaveChangesAsync() > 0;
            }
        }
        else
        {
            await db.Users.AddAsync(userObj);
            isSuccess = await db.SaveChangesAsync() > 0;
        }

        return isSuccess
            ? userObj
            : null;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    private async Task<string> GenerateJwtToken(UserEntity user)
    {
        //Generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();

        var token = await Task.Run(() =>
        {

            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.CreateToken(tokenDescriptor);
        });

        return tokenHandler.WriteToken(token);
    }
}