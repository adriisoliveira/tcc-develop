using APIController.Business.Entity.Logs;
using APIController.Business.Entity.Users;
using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Service.Logs;
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
    [Route("auth")]
    public class AuthController : BaseController
    {
        private readonly Microsoft.Extensions.Configuration.IConfiguration _config;
        private readonly IApiTokenLogService _apiTokenLogService;
        private readonly IUnitOfWork _uow;

        public AuthController(Microsoft.Extensions.Configuration.IConfiguration config,
            IApiTokenLogService apiTokenLogService,
            IUnitOfWork uow)
        {
            _config = config;
            _apiTokenLogService = apiTokenLogService;
            _uow = uow;
        }

        /// <summary>
        /// Método de geração de token JWT para autenticação.
        /// Obs: não necessário informar o JWT anterior.
        /// </summary>
        /// <param name="user">Dados de login</param>
        /// <returns>Token JWT</returns>
        [Route("authenticate")]
        [AllowAnonymous]
        [HttpPost]
        public IActionResult GenerateToken([FromBody] UserLoginApiModel user)
        {
            if (user.Login == "admin" && user.Password == "admin")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Login),
                };

                var credential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecretKey"])),
                    SecurityAlgorithms.HmacSha256);

                var tokenExpireDate = DateTime.Now.AddMinutes(20);

                var token = new JwtSecurityToken(
                    issuer: "apicontroller",
                    audience: "apicontroller",
                    claims: claims,
                    expires: tokenExpireDate,
                    signingCredentials: credential);
                
                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                _apiTokenLogService.Add(new ApiTokenLog(
                    Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                    Request.Headers["User-Agent"].ToString(),
                    jwt,
                    tokenExpireDate,
                    DateTime.UtcNow
                    ));
                _uow.Commit();

                return StatusCode(201, new { jwt = jwt });
                //return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }
            return BadRequest("E-mail ou senha incorretos");
        }
    }
}
