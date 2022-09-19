using Saitynai.Classes;

namespace Saitynai.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public byte[] PasswordHash { get; set; } // TODO hash password
    public byte[] PasswordSalt { get; set; } // TODO hash password
    public List<Playlist> Playlists { get; set; } = new List<Playlist>();
    public Role Role { get; set; }
}