using System.Text.Json.Serialization;
using Core.Entity.Base;

namespace Core.Entity;

public class UserEntity : BaseEntity
{
    public string? FirstName { get; set; }
    
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRoles UserRoles { get; set; }
}

