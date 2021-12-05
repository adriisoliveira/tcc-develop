using APIController.Annotations;
using APIController.Business.Interfaces.Service.Files;
using APIController.Business.Interfaces.Service.Users;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Claims;

namespace APIController.Controllers
{
    [EnableCors("EnableAllCrossOriginRequests")]
    [ApiController]
    [RegisterAccessLog]
    public class BaseController : ControllerBase
    {
        private IUserService _userService;

        public BaseController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Define se o usuário logado pode ou não acessar o determinado método de acordo com os tipos de usuário permitidos
        /// </summary>
        /// <param name="allowedUserType">Tipo de usuário permitido (podendo ser único ou em formado de Flags (UserType.X | UserType.Y | ...)</param>
        protected void CheckAccess(HttpContext context, Business.Enum.UserType allowedUserType)
        {
            var identity = context.User.Identity as ClaimsIdentity;

            if (identity == null)
                throw new PrivilegeNotHeldException();

            var email = identity.Claims.FirstOrDefault(e => e.Type == ClaimTypes.Email).Value;
            if (email == "admin")
                return;

            var user = _userService.GetByEmail(email);

            if (user == null || !allowedUserType.HasFlag(user.Type))
                throw new PrivilegeNotHeldException();
        }
    }
}
