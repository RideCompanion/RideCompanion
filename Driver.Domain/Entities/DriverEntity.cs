/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

using Shared.Abstractions.Entities;
#pragma warning disable CS8618

namespace Driver.Domain.Entities;

/// <summary>
/// Driver entity
/// </summary>
public class DriverEntity : IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// User Id
    /// </summary>
    public Guid UserId { get; init; }
    
    /// <summary>
    /// Cars
    /// </summary>
    public ICollection<CarEntity> Cars { get; set; }

    /// <summary>
    /// Full name
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Birth date
    /// </summary>
    public DateTime BirthDate { get; set; }

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