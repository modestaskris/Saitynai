using Saitynai.Models;

namespace Saitynai.DTO.Response;

public class SongRespDto
{
    public int SongId { get; set; }
    public string Url { get; set; }
    public int PlaylistId { get; set; }
    public bool Downloaded { get; set; }
    public DateTime? DownloadedDate { get; set; }
}