using Saitynai.Classes;
using Saitynai.Models;

namespace Saitynai.DTO.Response
{
    public class UserRespDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public Role Role { get; set; }
    }
}
