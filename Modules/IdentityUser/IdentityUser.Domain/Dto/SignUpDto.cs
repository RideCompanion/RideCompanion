namespace IdentityUser.Domain.Dto;

/// <summary>
/// Sign up Dto
/// </summary>
public class SignUpDto
{
    /// <summary>
    /// User Name
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Phone number
    /// </summary>
    public string? PhoneNumber { get; set; }
    
    /// <summary>
    /// Password
    /// </summary>
    public string? Password { get; set; }
    
    /// <summary>
    /// Repeat password
    /// </summary>
    public string? ConfirmPassword { get; set; }
  
    /// <summary>
    /// Full User Name
    /// </summary>
    public string? FullUserName { get; set; }
    
    /// <summary>
    /// Date of birth
    /// </summary>
    public DateTime DateOfBirth { get; set; }
}