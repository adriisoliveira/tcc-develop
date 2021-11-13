using APIController.Annotations;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIController.Controllers
{
    [EnableCors("EnableAllCrossOriginRequests")]
    [ApiController]
    [RegisterAccessLog]
    public class BaseController : ControllerBase
    {

    }
}
