using Saitynai.Models;

namespace Saitynai.DTO.Response;

public class CategoryRespDto
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    // public List<PlaylistRespDto>? Playlists { get; set; } = new List<PlaylistRespDto>();
}