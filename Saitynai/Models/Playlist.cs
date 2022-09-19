using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;

namespace Saitynai.Models;

public class Playlist
{
    public int Id { get; set; }
    // public int Id { get; set; } TODO cannot find by id
    public string Title { get; set; }
    [Required] [Key] public string Url { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
    public DateTime Created { get; set; }
}