using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Saitynai.Models;

public class Category
{
    [Key] public int CategoryId  { get; set; }
    [Required] public string Name { get; set; }
    [JsonIgnore]
    public List<Playlist>? Playlists { get; set; } = new List<Playlist>();
    [JsonIgnore]
    public User User { get; set; }
}