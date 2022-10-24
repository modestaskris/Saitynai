using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;

namespace Saitynai.Models;

public class Playlist
{
    [Key] 
    public int  PlaylistId { get; set; }
    [Required]
    public string Title { get; set; }
    [Required] 
    public string Url { get; set; }
    public Category Categorie { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
    public DateTime Created { get; set; }
}