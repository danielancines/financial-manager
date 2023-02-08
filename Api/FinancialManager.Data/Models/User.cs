using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FinancialManager.Data.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("login")]
    public string Login { get; set; } = string.Empty;

    [BsonElement("password")]
    public string Password { get; set; } = string.Empty;
    
    [BsonElement("name")]
    public string? Name { get; set; }
    
    [BsonElement("lastName")]
    public string? LastName { get; set; }
    public string? Roles { get; set; }
    public bool Active { get; set; }
}