using APIController.Business.Entity.Logs;
using APIController.Business.Entity.Users;
using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Service.Logs;
using APIController.Business.Interfaces.Service.Users;
using APIController.Helpers;
using APIController.Models.User;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IUserService _userService;
        private readonly IUnitOfWork _uow;

        public AuthController(Microsoft.Extensions.Configuration.IConfiguration config,
            IApiTokenLogService apiTokenLogService,
            IUnitOfWork uow,
            IUserService userService)
        {
            _config = config;
            _apiTokenLogService = apiTokenLogService;
            _uow = uow;
            _userService = userService;
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
            var userDb = _userService.GetByEmail(user.Login);
            if (
                //Login via admin
                (user.Login == "admin" && user.Password == "admin")
                //Login via banco
                || (userDb != null && userDb.Password == StringHelper.CreateMD5(user.Password)))
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, userDb != null ? userDb.Name : "admin"),
                    new Claim(ClaimTypes.Email, userDb != null ? userDb.Email: "admin")
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
            }
            return BadRequest("E-mail ou senha incorretos");
        }

        [Authorize()]
        [Route("createUser")]
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserManageModel user)
        {
            try
            {
                _userService.Add(new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    CPF = user.CPF,
                    Type = user.Type,
                    Password = StringHelper.CreateMD5(user.Password)
                });
                return StatusCode(200);
            }
            catch (Exception ex) { return BadRequest("Erro ao criar usuário: " + ex.Message); }
        }
    }
}
