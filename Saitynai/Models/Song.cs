using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Saitynai.Models;

public class Song
{
    [Key]
    public int SongId { get; set; }
    [Required] public string Url { get; set; }
    [JsonIgnore]
    public Playlist Playlist { get; set; }
    public bool Downloaded { get; set; }
    [JsonIgnore]
    public DateTime? DownloadedDate { get; set; }
}