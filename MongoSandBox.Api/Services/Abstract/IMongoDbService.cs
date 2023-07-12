using MongoDB.Driver;
using MongoSandBox.Api.Models;

namespace MongoSandBox.Api.Services.Abstract;

public interface IMongoDbService<T> where T : BaseCollection, new()
{
    IMongoCollection<T> MongoDbCollection { get; set; }

    Task CreateAsync(T collection);
    Task<List<T>> GetCollectionAsync();
    Task AddToPlaylistAsync(string id, string movieId);
    Task DeleteAsync(string id);
}
