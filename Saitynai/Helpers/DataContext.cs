using Microsoft.EntityFrameworkCore;
using Saitynai.Models;

namespace Saitynai.Helpers;

public class DataContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Playlist> Playlists { get; set; }
    public DbSet<Song> Songs { get; set; }

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

    // TODO add connection string
}