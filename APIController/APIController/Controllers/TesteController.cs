using APIController.Business.Entity.Users;
using APIController.Business.Interfaces.Service.Users;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIController.Controllers
{
    [ApiController]
    [Route("teste")]
    public class TesteController : ControllerBase
    {
        protected IUserService _userService;
        public TesteController(IUserService userService)
        {
            _userService = userService;
        }
        public IEnumerable<User> Index()
        {
            return _userService.GetAll();
        }
    }
}
