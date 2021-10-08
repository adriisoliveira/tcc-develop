using Microsoft.AspNetCore.Mvc;

namespace WebCrawler.API.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public class TesteController : ControllerBase
    {
        public string Teste()
        {
            return "HELLO WORLD!";
        }
    }
}
