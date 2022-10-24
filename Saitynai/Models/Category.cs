using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Saitynai.Models;

public class Category
{
    [Key] public int CategoryId  { get; set; }
    [Required] public string Name { get; set; }
    public List<Playlist>? Playlists { get; set; } = new List<Playlist>();
    public User User { get; set; }
}