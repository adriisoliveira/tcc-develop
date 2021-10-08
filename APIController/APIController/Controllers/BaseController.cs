using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace APIController.Controllers
{
    [ApiController]
    [Authorize()]
    public class BaseController : ApiController
    {

    }
}
