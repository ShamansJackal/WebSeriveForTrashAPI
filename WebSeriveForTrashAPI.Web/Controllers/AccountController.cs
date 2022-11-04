using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebSeriveForTrashAPI.Controllers
{
    internal record Person(string Login, string Password)
    {
    }

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Token(string username, string password)
        {
            var identity = GetIdentity(username, password);

            if (identity == null) return BadRequest(new { errorText = "Invalid username or password." });

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                Environment.GetEnvironmentVariable("JwtKey") ?? throw new Exception("JWT signature key not found")
            ));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                Environment.GetEnvironmentVariable("JwtIssuer"),
                Environment.GetEnvironmentVariable("JwtIssuer"),
                identity.Claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            Person person = new(
                Environment.GetEnvironmentVariable("AdminLogin"),
                Environment.GetEnvironmentVariable("AdminPassword")
            );
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, "Admin")
                };
                ClaimsIdentity claimsIdentity = new(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }
    }
}
