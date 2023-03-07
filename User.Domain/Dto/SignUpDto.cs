/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace User.Domain.Dto;

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
    
    /// <summary>
    /// Driver Id
    /// </summary>
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Companion Id
    /// </summary>
    public Guid CompanionId { get; set; }
}