namespace Shared.Core.Entities;

public interface IBaseEntity : IAuditableEntity
{
    /// <summary>
    /// Id
    /// </summary>
    public Guid Id { get; set; }
}