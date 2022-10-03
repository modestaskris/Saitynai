using System.Text.Json.Serialization;
using Saitynai.Models;

namespace Saitynai.DTO;

public class PlaylistDetails
{
    public int PlaylistId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    // [JsonIgnore]
    public List<Song> Songs { get; set; } = new List<Song>();
    [JsonIgnore]
    public DateTime Created { get; set; }
}