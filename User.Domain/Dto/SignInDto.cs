namespace User.Domain.Dto;

/// <summary>
/// Sign in Dto
/// </summary>
public class SignInDto
{
    public SignInDto(string email, string password)
    {
        Email = email;
        Password = password;
    }

    /// <summary>
    /// User name
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
}