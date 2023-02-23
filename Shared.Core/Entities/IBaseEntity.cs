/*
 * Date: 2023-02-23
 * Author: A.A.Konkin
*/

namespace Shared.Core.Entities;

public interface IBaseEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}