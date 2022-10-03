namespace Saitynai.DTO;

public class CategoryDetails
{
    public int CategoryId { get; set; }
    public string Name { get; set; }
    public List<PlaylistDetails> Playlists { get; set; } = new List<PlaylistDetails>();
}