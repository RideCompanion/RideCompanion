using Shared.Core.BaseEntities;
using System.Text.Json.Serialization;

namespace Identity.Domain.Entities;

public class UserEntity : BaseAuditableEntity
{
    public required string FirstName { get; set; }
    public string LastName { get; set; }
    public required string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
    public bool IsActive { get; set; }
}