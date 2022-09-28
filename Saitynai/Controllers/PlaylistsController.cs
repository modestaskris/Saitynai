using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.CompilerServices;
using Saitynai.DTO;
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
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
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

            List<Playlist> playlists = new List<Playlist>();
            
            foreach (var c in categories)
            {
                foreach (var p in c.Playlists)
                {
                    playlists.Add(p);
                }
            }

            return Ok(playlists);
        }

        // GET: api/Playlists/{id}
        [HttpGet("{id}")] // TODO probably bad request type
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
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

            return playlist;
        }

        // PUT: api/Playlists/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, PlaylistDTO request)
        {
            // TODO check if request.categorie exists and if class props are valid
            var playlist = GetUserPlaylist(id);

            if (playlist == null)
            {
                BadRequest("Playlist url does not exists");
            }

            playlist.Url = request.Url;
            playlist.Title= request.PlaylistName;
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

            return NoContent();
        }

        // POST: api/Playlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(PlaylistDTO request)
        {
            // TODO if user deletes playlist, also delete songs...
            if (_context.Playlists == null)
            {
                return Problem("Entity set 'DataContext.Playlists'  is null.");
            }

            var category = GetCategorie(request.CategorieName);
            if (category == null)
            {
                return BadRequest($"Category {request.CategorieName} does not exists");
            }

            Playlist playlist = new Playlist()
            {
                Categorie = category, Created = DateTime.Now, Title = request.PlaylistName, Songs = new List<Song>(),
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

            return CreatedAtAction("PostPlaylist", playlist);
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
    }
}