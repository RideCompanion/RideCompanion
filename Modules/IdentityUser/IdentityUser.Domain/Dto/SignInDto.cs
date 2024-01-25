#pragma warning disable CS8618
namespace IdentityUser.Domain.Dto;

/// <summary>
/// Sign in dto
/// </summary>
public class SignInDto
{
    /// <summary>
    /// User name
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; }
    
    /// <summary>
    /// Remember me
    /// </summary>
    public bool RememberMe { get; set; }
}