using Saitynai.Models;

namespace Saitynai.DTO.Response;

public class PlaylistRespDto
{
    public int PlaylistId { get; set; }
    public string Title { get; set; }
    public string Url { get; set; }
    public int CategoryId { get; set; }
    // public List<SongRespDto> Songs { get; set; } = new List<SongRespDto>();
    public DateTime Created { get; set; }
}