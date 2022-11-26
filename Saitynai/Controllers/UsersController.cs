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
using Saitynai.Services;

namespace Saitynai.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly DataContext _context;
        private readonly ICustomMapper _customMapper;

        public UsersController(DataContext context, ICustomMapper customMapper)
        {
            _context = context;
            _customMapper = customMapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRespDto>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            var convertedUsers = new List<UserRespDto>();
            
            foreach(var user in users)
            {
                convertedUsers.Add(_customMapper.Mapper(user));
            }

            return convertedUsers;
        }

        // GET: api/Users/5
        [HttpGet("{username}")]
        public async Task<ActionResult<UserRespDto>> GetUser(string username)
        {
            var user = await _context.Users.FindAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return _customMapper.Mapper(user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _context.Users.FindAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Username == id);
        }
    }
}
