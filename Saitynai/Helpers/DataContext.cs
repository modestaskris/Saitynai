using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Saitynai.Classes;
using Saitynai.Models;

namespace Saitynai.Helpers;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<Category>? Category { get; set; }

    public string DbPath { get; }

    protected readonly IConfiguration _configuration;

    public DataContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        
        => options.UseSqlServer(_configuration.GetConnectionString("YPSApiDatabase"));

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.


    #region Required
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        string password = "admin";
        CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        modelBuilder.Entity<User>().HasData(new User
        {
            UserId = -1,
            Username= "admin",
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            Role = Role.Admin,
            Categories = new List<Category>(),
        });

    }
    #endregion

    private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
}