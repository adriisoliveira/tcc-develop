using APIController.Business.Entity.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("summy")]
    public class SummyController : ControllerBase
    {
        
    }
}
