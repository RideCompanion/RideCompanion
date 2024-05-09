using Identity.Domain.Entities;

namespace Identity.Infrastructure.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);

    /// <summary>
    ///
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<UserEntity>> GetAll();

    /// <summary>
    ///
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<UserEntity?> GetById(Guid id);

    /// <summary>
    ///
    /// </summary>
    /// <param name="userObj"></param>
    /// <returns></returns>
    Task<UserEntity?> AddAndUpdateUser(UserEntity userObj);
}