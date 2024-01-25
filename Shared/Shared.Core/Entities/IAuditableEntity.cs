namespace Shared.Core.Entities;

public interface IAuditableEntity
{
    /// <summary>
    /// Создал
    /// </summary>
    public Guid CreatedById { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// Обновил
    /// </summary>
    public Guid UpdateById { get; set; }

    /// <summary>
    /// Дата обновления
    /// </summary>
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// Флаг удаления true - удален, false - не удален
    /// </summary>
    public bool IsDeleted { get; set; }
}