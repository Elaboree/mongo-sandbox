namespace MongoSandBox.Api.Models;

public class MongoDbSettings
{
    public string? ConnectionURI { get; set; }
    public string? DbName { get; set; }
    public string? CollectionName{ get; set; }
}