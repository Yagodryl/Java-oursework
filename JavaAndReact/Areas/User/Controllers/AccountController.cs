using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JavaAndReact.Areas.User.ViewModels;
using JavaAndReact.BLL.Interfaces;
using JavaAndReact.Entities;
using JavaAndReact.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JavaAndReact.Areas.User.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    //[ApiController]
    public class AccountController : ControllerBase
    {
        private readonly EFDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly UserManager<DbUser> _userManager;
        private readonly IHostingEnvironment _env;
        private readonly IJWTTokenService _tokenService;
        private readonly SignInManager<DbUser> _signInManager;
             
        public AccountController(IHostingEnvironment env,
            IConfiguration configuration,
            IJWTTokenService tokenService,
            EFDbContext context,
            UserManager<DbUser> userManager,
            SignInManager<DbUser> signInManager)
        {
            _tokenService = tokenService;
            _configuration = configuration;
            _env = env;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                var errrors = CustomValidator.GetErrorsByModel(ModelState);
                return BadRequest(errrors);
            }
            var result = await _signInManager
                .PasswordSignInAsync(model.Email, model.Password,
                false, false);
            if (!result.Succeeded)
            {
                return BadRequest(new { invalid = "Не правильно введені дані!" });
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Ok(
            new
            {
                token = _tokenService.CreateToken(user),
                refToken = _tokenService.CreateRefreshToken(user)
            });
        }
    }
}