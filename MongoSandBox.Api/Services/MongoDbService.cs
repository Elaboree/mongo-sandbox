using MongoDB.Driver;
using MongoSandBox.Api.Models;
using Microsoft.Extensions.Options;
using MongoSandBox.Api.Services.Abstract;
using MongoDB.Bson;

namespace MongoSandBox.Api.Services;

public class MongoDbService<TCollection> : IMongoDbService<TCollection> where TCollection : BaseCollection, new()
{
    //Needs generic repository implementation
    public IMongoCollection<TCollection> MongoDbCollection { get; set; }

    public MongoDbService(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(connectionString: settings.Value.ConnectionURI);
        var mongoDatabase = client.GetDatabase(settings.Value.DbName);
        MongoDbCollection = mongoDatabase.GetCollection<TCollection>(settings.Value.CollectionName);
    }

    public async Task CreateAsync(TCollection collection)
    {
        await MongoDbCollection.InsertOneAsync(collection);
        return;
    }

    public async Task<List<TCollection>> GetCollectionAsync()
    {
        return await MongoDbCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task AddToPlaylistAsync(string id, string movieId)
    {
        FilterDefinition<TCollection> filter = Builders<TCollection>.Filter.Eq("Id", id);
        UpdateDefinition<TCollection> update = Builders<TCollection>.Update.AddToSet<string>("items", movieId);
        await MongoDbCollection.UpdateOneAsync(filter,update);
        return;
    }


    public async Task DeleteAsync(string id)
    {
        FilterDefinition<TCollection> filter = Builders<TCollection>.Filter.Eq("Id",id);
        await MongoDbCollection.DeleteOneAsync(filter);
        return;
    }
}