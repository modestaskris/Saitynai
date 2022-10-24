using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saitynai.DTO;
using Saitynai.DTO.Response;
using Saitynai.Helpers;
using Saitynai.Models;

namespace Saitynai.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : BaseController
    {
        private readonly DataContext _context;

        public SongsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SongRespDto>>> GetSongs()
        {
            var playlists = GetUserPlaylists();
            var songs = new List<SongRespDto>();

            foreach (var p in playlists)
            {
                foreach (var song in p.Songs)
                {
                    songs.Add(Mapper(song));
                }
            }

            return songs;
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SongRespDto>> GetSong(int id)
        {
            var song = GetUserSongs().Find(x => x.SongId == id);

            if (song == null)
            {
                return NotFound();
            }

            var mappedSong = Mapper(song);

            return mappedSong;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<SongRespDto>> PutSong(int id, SongDTO request)
        {
            var playlist = GetUserPlaylists().FirstOrDefault(x => x.PlaylistId == request.PlaylistId);
            if (playlist == null)
            {
                return BadRequest($"PlaylistId {request.PlaylistId} does not found");
            }

            var song = GetSongById(id);
            song.Url = request.Url;
            song.Playlist = playlist;

            _context.Entry(song).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var mappedSong = Mapper(song);

            return Ok(mappedSong);
        }

        // POST: api/Songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(SongDTO request)
        {
            var playlist = GetUserPlaylist(request.PlaylistId);
            if (playlist == null)
            {
                return BadRequest($"PlaylistId {request.PlaylistId} does not found");
            }

            var song = new Song()
                { Downloaded = false, Url = request.Url, DownloadedDate = null, Playlist = playlist };


            _context.Songs.Add(song);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SongExists(song.SongId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var a = Mapper(song);

            return CreatedAtAction("GetSong", new { id = a.Url }, a);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            var song = GetSongById(id);
            if (song == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(song);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SongExists(int id)
        {
            return _context.Songs.Any(e => e.SongId == id);
        }

        private User GetCurrentUser()
        {
            return _context.Users
                .Include(x => x.Categories)
                .ThenInclude(x => x.Playlists)
                .ThenInclude(x => x.Songs)
                .FirstOrDefault(x => x.Username.Equals(User));
        }

        private Category? GetCategorie(string categName)
        {
            // TODO include playlists
            var categorie = GetCurrentUser().Categories.Find(x => x.Name.Equals(categName));
            if (categorie == null)
            {
                // throw new Exception($"Category {categName} not found");
                // TODO add LOGGING
                return null;
            }

            return categorie;
        }

        private List<Playlist> GetUserPlaylists()
        {
            var categories = GetCurrentUser().Categories;
            var playlists = new List<Playlist>();

            foreach (var category in categories)
            {
                foreach (var plist in category.Playlists)
                {
                    playlists.Add(plist);
                }
            }

            return playlists;
        }


        private Playlist? GetUserPlaylist(int id)
        {
            var playlist = GetUserPlaylists().FirstOrDefault(x => x.PlaylistId == id);

            if (playlist == null)
            {
                // throw new Exception($"PlaylistId {id} not found");
                // TODO add logging
                return null;
            }

            return playlist;
        }

        private List<Song> GetUserSongs()
        {
            List<Song> songs = new List<Song>();

            var playlists = GetUserPlaylists();
            foreach (var playlist in playlists)
            {
                foreach (var song in playlist.Songs)
                {
                    songs.Add(song);
                }
            }

            return songs;
        }

        private Song? GetSongById(int id)
        {
            var songs = GetUserSongs();
            var song = songs.FirstOrDefault(x => x.SongId == id);

            if (song == null)
            {
                // TODO add logging
                return null; // if did not found
            }

            return song;
        }

        private PlaylistRespDto Mapper(Playlist p)
        {
            var songs = new List<SongRespDto>();

            foreach (var song in p.Songs)
            {
                songs.Append(Mapper(song));
            }

            return new PlaylistRespDto()
            {
                CategoryId = p.Categorie.CategoryId,
                // Songs = songs,
                Created = p.Created,
                PlaylistId = p.PlaylistId,
                Title = p.Title,
                Url = p.Url
            };
        }

        private SongRespDto Mapper(Song song)
        {
            return new SongRespDto()
            {
                SongId = song.SongId,
                PlaylistId = song.Playlist.PlaylistId,
                Downloaded = song.Downloaded,
                DownloadedDate = song.DownloadedDate,
                Url = song.Url
            };
        }
    }
}