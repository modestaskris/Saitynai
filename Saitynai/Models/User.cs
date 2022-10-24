using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
// using Newtonsoft.Json;
using Saitynai.Classes;

namespace Saitynai.Models;

public class User
{
    [JsonIgnore]
    public int UserId { get; set; }
    [Key] public string Username { get; set; }
    public byte[] PasswordHash { get; set; } // TODO hash password
    public byte[] PasswordSalt { get; set; } // TODO hash password
    public List<Category> Categories { get; set; } = new List<Category>();
    public Role Role { get; set; }
}