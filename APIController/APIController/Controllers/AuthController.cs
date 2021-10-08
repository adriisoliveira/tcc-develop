using APIController.Business.Entity.Users;
using APIController.Models;
using APIController.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIController.Controllers
{
    [ApiController]
    [Route("auth")]
    [EnableCors("EnableAllCrossOriginRequests")]
    public class AuthController : ControllerBase
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        public AuthController(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }

        [Route("authenticate")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] UserLoginApiModel user)
        {
            if (user.Login == "admin" && user.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                };

                var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"])),
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "apicontroller",
                    audience: "apicontroller",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credential);

                return StatusCode(201, new { jwt = new JwtSecurityTokenHandler().WriteToken(token) });
                //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest("E-mail ou senha incorretos");
        }
    }
}
