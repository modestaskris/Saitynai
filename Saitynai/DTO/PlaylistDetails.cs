using System.Text.Json.Serialization;
using Saitynai.DTO.Response;
using Saitynai.Models;

namespace Saitynai.DTO;

public class PlaylistDetails
{
    public int PlaylistId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    // [JsonIgnore]
    public List<SongRespDto> Songs { get; set; } = new List<SongRespDto>();
    [JsonIgnore]
    public DateTime Created { get; set; }
}