using JavaAndReact.BLL.Interfaces;
using JavaAndReact.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JavaAndReact.BLL.Services
{
    public class JWTTokenService: IJWTTokenService
    {
        private readonly EFDbContext _context;
        private readonly UserManager<DbUser> _userManager;
        private readonly IConfiguration _configuration;

        public JWTTokenService(IConfiguration configuration,
            UserManager<DbUser> userManager,
            EFDbContext context)
        {
            _configuration = configuration;
            _userManager = userManager;
            _context = context;
        }

        public string CreateRefreshToken(DbUser user)
        {
            var _refreshToken = _context.RefreshTokens
               .SingleOrDefault(m => m.Id == user.Id);
            if (_refreshToken == null)
            {
                RefreshToken t = new RefreshToken
                {
                    Id = user.Id,
                    Token = Guid.NewGuid().ToString()
                };
                _context.RefreshTokens.Add(t);
                _context.SaveChanges();
                _refreshToken = t;
            }
            else
            {
                _refreshToken.Token = Guid.NewGuid().ToString();
                _context.RefreshTokens.Update(_refreshToken);
                _context.SaveChanges();
            }
            return _refreshToken.Token;
        }

        public string CreateToken( DbUser user)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var claims = new List<Claim>()
            {
                //new Claim(JwtRegisteredClaimNames.Sub, user.Id)
                new Claim("id", user.Id.ToString()),
                new Claim("name", user.UserName)
            };
            foreach (var role in roles)
            {
                claims.Add(new Claim("roles", role));
            }
            // var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("SecretPhrase")));
            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretPhrase"));

            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15));
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }
    }
}
