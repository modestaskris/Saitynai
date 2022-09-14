using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Saitynai.Models;

public class Song
{
    [Key] public string Url { get; set; }
    public bool Downloaded { get; set; }
    public DateTime DownloadedDate { get; set; }
}