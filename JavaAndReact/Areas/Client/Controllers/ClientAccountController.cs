using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaAndReact.Areas.Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JavaAndReact.Areas.Client.Controllers
{
    [Route("api/Account")]
    [ApiController]
    public class ClientAccountController : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]ClientAddViewModel model)
        {
        //    var userByEmail = _context.Users.SingleOrDefault(u => u.Email == model.Email);
        //    if (userByEmail != null)
        //    {
        //        var invalid = new Dictionary<string, string>();
        //        invalid.Add("email", "Користувач з даною електронною поштою уже зареєстрований");
        //        return BadRequest(invalid);
        //    }

            return Ok();
        }
    }
}