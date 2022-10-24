using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using Saitynai.DTO;
using Saitynai.DTO.Response;
using Saitynai.Helpers;
using Saitynai.Models;

namespace Saitynai.Controllers
{
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistsController : BaseController
    {
        private readonly DataContext _context;

        public PlaylistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Playlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistRespDto>>> GetPlaylists()
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();
            var categories = user.Categories;

            if (categories == null)
            {
                // TODO thow error that categorie does not exits;
                BadRequest("Category does not exist");
            }

            List<PlaylistRespDto> playlists = new List<PlaylistRespDto>();

            foreach (var c in categories)
            {
                foreach (var p in c.Playlists)
                {
                    playlists.Add(Mapper(p));
                }
            }

            return Ok(playlists);
        }

        // GET: api/Playlists/{id}
        [HttpGet("{id}")] // TODO probably bad request type
        public async Task<ActionResult<PlaylistRespDto>> GetPlaylist(int id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = GetUserPlaylist(id);

            if (playlist == null)
            {
                return NotFound();
            }

            var mappedPlaylist = Mapper(playlist);

            return mappedPlaylist;
        }

        // GET: api/Playlists/{id}
        [HttpGet("{id}/songs")] // TODO probably bad request type
        public async Task<ActionResult<IEnumerable<SongRespDto>>> GetPlaylistSongs(int id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = GetUserPlaylist(id);

            if (playlist == null)
            {
                return NotFound();
            }

            List<SongRespDto> songs = new List<SongRespDto>();

            foreach (var s in playlist.Songs)
            {
                songs.Add(Mapper(s));
            }

            return songs;
        }

        // PUT: api/Playlists/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<PlaylistRespDto>> PutPlaylist(int id, PlaylistDTO request)
        {
            // TODO playlist dto does not need to have categroyID
            // TODO check if request.categorie exists and if class props are valid
            var playlist = GetUserPlaylist(id);

            if (playlist == null)
            {
                BadRequest("Playlist url does not exists");
            }

            playlist.Url = request.Url;
            playlist.Title = request.Title;
            _context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (playlist == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            var p = Mapper(playlist);

            return Ok(p);
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlaylistRespDto>> PostPlaylist(PlaylistDTO request)
        {
            // TODO test middleware, url cannot be null...
            // TODO if user deletes playlist, also delete songs...
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'DataContext.Playlists'  is null.");
            }

            var category = GetCategory(request.CategoryId);
            if (category == null)
            {
                return BadRequest($"Category {request.CategoryId} does not exists");
            }

            Playlist playlist = new Playlist()
            {
                Categorie = category, Created = DateTime.Now, Title = request.Title, Songs = new List<Song>(),
                Url = request.Url
            };
            _context.Playlists.Add(playlist);

            category.Playlists.Add(playlist);

            _context.Entry(category).State = EntityState.Modified;
            // TODO maybe here is no need to update category, because it only creates foreign key

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PlaylistExists(playlist.Url))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            var a = Mapper(playlist);

            return CreatedAtAction("PostPlaylist", a);
        }

        // DELETE: api/Playlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            if (_context.Playlists == null)
            {
                return NotFound();
            }

            var playlist = GetUserPlaylist(id);

            if (playlist == null)
            {
                return NotFound($"PlaylistId: {id} does not exists");
            }

            _context.Playlists.Remove(playlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlaylistExists(string url)
        {
            return (_context.Playlists?.Any(e => e.Url == url)).GetValueOrDefault();
        }

        private User GetCurrentUser()
        {
            return _context.Users
                .Include(x => x.Categories)
                .ThenInclude(x => x.Playlists)
                .ThenInclude(x => x.Songs)
                .FirstOrDefault(x => x.Username.Equals(User));
        }

        private Category? GetCategory(int categId)
        {
            // TODO include playlists
            var category = GetCurrentUser().Categories.Find(x => x.CategoryId.Equals(categId));
            if (category == null)
            {
                // throw new Exception($"Category {categId} not found");
                // TODO add LOGGING
                return null;
            }

            return category;
        }

        private Playlist? GetUserPlaylist(int id)
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

            var playlist = playlists.FirstOrDefault(x => x.PlaylistId == id);

            if (playlist == null)
            {
                // throw new Exception($"PlaylistId {id} not found");
                // TODO add logging
                return null;
            }

            return playlist;
        }

        private PlaylistRespDto Mapper(Playlist p)
        {
            var songs = new List<SongRespDto>();

            foreach (var song in p.Songs)
            {
                // songs.Append(Mapper(song));
            }

            return new PlaylistRespDto()
            {
                CategoryId = p.Categorie.CategoryId, 
                // Songs = songs, 
                Created = p.Created, PlaylistId = p.PlaylistId,
                Title = p.Title, Url = p.Url
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