/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace Shared.Abstractions.Entities;

public interface IBaseEntity : IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}