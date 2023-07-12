using Microsoft.AspNetCore.Mvc;
using MongoSandBox.Api.Models;
using MongoSandBox.Api.Services.Abstract;

namespace MongoSandBox.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlaylistController : Controller
{
    private readonly IMongoDbService<Playlist> mongoDbService;
    public PlaylistController(IMongoDbService<Playlist> mongoDbService)
    {
        this.mongoDbService = mongoDbService;
    }

    [HttpGet]
    public async Task<List<Playlist>> Get()
    {
        return await mongoDbService.GetCollectionAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Playlist playlist)
    {
        await mongoDbService.CreateAsync(playlist);
        return CreatedAtAction(nameof(Post), new { id = playlist.Id }, playlist);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AddToPlaylist(string id, [FromBody] string movieId)
    {
        await mongoDbService.AddToPlaylistAsync(id, movieId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await mongoDbService.DeleteAsync(id);
        return NoContent();
    }
}