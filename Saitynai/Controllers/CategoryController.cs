using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Saitynai.Classes;
using Saitynai.DTO;
using Saitynai.Helpers;
using Saitynai.Models;

namespace Saitynai.Controllers
{
    // TODO get only user categories and allow only to user use these api endpoints
    // TODO seems like done
    [Authorize(Roles = "User, Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BaseController
    {
        private readonly DataContext _context;

        public CategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            if (_context.Category == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();

            var categories = user.Categories.ToList();

            return Ok(categories);
        }

        // GET: api/Category/{id}
        [HttpGet("{id}/playlists")]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetCategoriePlaylists(int id)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();
            var category = user.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound($"CategoryId {id} does not found");
            }

            return category.Playlists;
        }

        [HttpGet("{id}/playlists/{playlistId}/songs")]
        public async Task<ActionResult<IEnumerable<Song>>> GetCategoriePlaylistsSongs(int id, int playlistId)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();
            var category = user.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound($"CategoryId {id} does not found");
            }

            var playlist = category.Playlists.FirstOrDefault(x => x.PlaylistId == playlistId);
            if (playlist == null)
            {
                return BadRequest($"Playlist id not found");
            }

            return playlist.Songs;
        }

        // TODO do not use custom class, maybe there is possible to use models...
        [HttpGet("{id}/details")]
        public async Task<ActionResult<CategoryDetails>> GetCategorieDetails(int id)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();
            var category = user.Categories.FirstOrDefault(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound($"CategoryId {id} does not found");
            }

            List<PlaylistDetails> playlistDetails = new List<PlaylistDetails>();
            foreach (var p in category.Playlists)
            {
                PlaylistDetails newPlaylistDetails = new PlaylistDetails()
                    { Created = p.Created, Url = p.Url, Title = p.Title, PlaylistId = p.PlaylistId, Songs = p.Songs };
                playlistDetails.Add(newPlaylistDetails);
            }


            CategoryDetails categoryDetails = new CategoryDetails()
                { CategoryId = category.CategoryId, Name = category.Name, Playlists = playlistDetails };

            return categoryDetails;
        }

        // GET: api/Category/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategorie(int id)
        {
            if (_context.Category == null)
            {
                return NotFound();
            }
        
            var user = GetCurrentUser();
            var category = user.Categories.FirstOrDefault(x => x.CategoryId == id);
        
            if (category == null)
            {
                return NotFound($"CategoryId {id} does not found");
            }
        
            return category;
        }

        // PUT: api/Category/{id}
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDTO request) // id current name, 
        {
            var user = GetCurrentUser();
            var category = user.Categories.Find(x => x.CategoryId == id);

            if (category == null)
            {
                return BadRequest($"CategoryId {id} does not exists");
            }

            category.Name = request.Name;

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategorie(CategoryDTO request)
        {
            if (_context.Category == null)
            {
                return Problem("Entity set 'DataContext.Category'  is null.");
            }

            // TODO allow create only unique name categorie...

            var user = GetCurrentUser();

            // TODO use category id, not name....
            Category newCategory = new Category()
                { Name = request.Name, User = user, Playlists = new List<Playlist>() };

            _context.Category.Add(newCategory);
            await _context.SaveChangesAsync();

            user.Categories.Add(newCategory);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync(); // TODO cia luzta..


            return CreatedAtAction("GetCategory", new { id = newCategory.CategoryId }, newCategory);
        }

        // DELETE: api/Categories/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategorie(int id)
        {
            // TODO if user deletes categorie, also delete playlists and songs...
            if (_context.Category == null)
            {
                return NotFound();
            }

            var user = GetCurrentUser();
            var category = user.Categories.Find(x => x.CategoryId == id);

            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategorieExists(int id)
        {
            return (_context.Category?.Any(e => e.CategoryId == id)).GetValueOrDefault();
        }

        private User GetCurrentUser()
        {
            if (_context.Users == null)
            {
                throw new Exception("_context.Users is null");
            }
            return _context.Users
                .Include(x => x.Categories)
                .ThenInclude(x=> x.Playlists) // todo not include 
                .ThenInclude(x => x.Songs) // todo not include
                .FirstOrDefault(x => x.Username.Equals(User));
        }
    }
}