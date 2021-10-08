using APIController.Business.Entity.Users;
using APIController.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("auth")]
    public class AuthController : BaseController
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        public AuthController(Microsoft.Extensions.Configuration.IConfiguration config)
        {
            _config = config;
        }

        [Route("authenticate")]
        [AllowAnonymous]
        [HttpPost]
        public HttpResponseMessage RequestToken([FromBody] UserLoginModel user)
        {
            if (user.Login == "admin" && user.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Login),
                    //new Claim(ClaimTypes.Role, user.Type.ToString())
                };

                var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"])),
                    SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "apicontroller",
                    audience: "apicontroller",
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(60),
                    signingCredentials: credential);
                return Request.CreateResponse(HttpStatusCode.OK,
                    new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "E-mail ou senha incorretos");
        }
    }
}
