using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Saitynai.Models;

namespace Saitynai.Controllers
{
    [Controller]
    public abstract class BaseController : ControllerBase
    {
        public string User
        {
            get
            {
                return HttpContext.User.Claims.FirstOrDefault(x => x.Type == "username").Value;
            }
        }
    }
}
