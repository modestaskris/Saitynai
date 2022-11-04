using Microsoft.EntityFrameworkCore;
using Saitynai.Helpers;
using Saitynai.Models;
using Saitynai.Services;

namespace Saitynai.Repositories;

public interface IUserRepository
{
    User? GetUser();
    IEnumerable<Category> GetUserCategories();
    Category GetUserCategory(int id);
    IEnumerable<Playlist> GetUserPlaylists();
    IEnumerable<Playlist> GetUserPlaylists(int categoryId);
    Playlist GetUserPlaylist(int playlistId);
    IEnumerable<Song> GetUserSongs();
    IEnumerable<Song> GetUserSongs(int playlistId);
}

public class UserRepository : IUserRepository
{
    private readonly DataContext _dataContext;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ICustomMapper _customMapper;

    public UserRepository(DataContext dataContext, IHttpContextAccessor httpContextAccessor, ICustomMapper customMapper)
    {
        this._dataContext = dataContext;
        this._contextAccessor = httpContextAccessor;
        this._customMapper = customMapper;
    }

    public User? GetUser()
    {
        if (_dataContext.Users == null)
        {
            throw new Exception("_context.Users is null");
        }

        var username = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username")?.Value;

        if (username == null)
        {
            throw new Exception($"Current user with username: {username} is null, aborting request...");
        }

        var user = _dataContext.Users
            .Include(x => x.Categories)
            .ThenInclude(x => x.Playlists)! // todo not include  // added ! because playlist can be null
            .ThenInclude(x => x.Songs) // todo not include
            .FirstOrDefault(x => x.Username.Equals(username));

        return user;
    }

    public IEnumerable<Category> GetUserCategories()
    {
        var user = this.GetUser();
        if (user == null)
        {
            throw new Exception($"User {user.Username} is null");
        }

        var categories = user.Categories.ToList();
        return categories;
    }

    public Category GetUserCategory(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Playlist> GetUserPlaylists()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Playlist> GetUserPlaylists(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Playlist GetUserPlaylist(int playlistId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Song> GetUserSongs()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Song> GetUserSongs(int playlistId)
    {
        throw new NotImplementedException();
    }
}