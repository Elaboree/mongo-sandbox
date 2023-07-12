using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoSandBox.Api.Models;

public class BaseCollection
{
    [BsonId]
    [BsonElement("_id")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
}
public class Playlist : BaseCollection
{
    //TODO: Serialize?
    public string? username { get; set; }

    [BsonElement("items")]
    [JsonPropertyName("items")]
    public List<string>? movieIds { get; set; }
}