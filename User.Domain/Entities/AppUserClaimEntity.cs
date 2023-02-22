using System.ComponentModel.DataAnnotations;
using Shared.Core.Entities;

namespace User.Domain.Entities;

/// <summary>
/// App User Claim Entity
/// </summary>
public class AppUserClaimEntity : IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    
    /// <summary>
    /// App user Id
    /// </summary>
    public Guid AppUserId { get; set; }
    public AppUserEntity? AppUser { get; set; }
    
    /// <summary>
    /// Claim Id
    /// </summary>
    public Guid ClaimId { get; set; }
    public ClaimEntity? Claim { get; set; }

    /// <summary>
    /// Id created user
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Created date
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Id updated user
    /// </summary>
    public Guid UpdateById { get; set; }

    /// <summary>
    /// Update date
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Is deleted flag
    /// </summary>
    public bool IsDeleted { get; set; }
}