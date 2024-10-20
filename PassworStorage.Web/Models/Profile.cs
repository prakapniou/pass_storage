using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PasswordStorage.Web.Models;

public class Profile
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public Guid IdMyProperty { get; set; }

    [BsonElement("Name")]
    public string? Name { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public List<string>? Codes { get; set; } = [];
    public string? Note { get; set; }
}
