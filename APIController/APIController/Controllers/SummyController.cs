using APIController.Models.Summarization;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIController.Controllers
{
    //[Authorize()]
    [ApiController]
    [Route("summarization")]
    public class SummyController : ControllerBase
    {
        protected IApiClient _client;
        public SummyController(IApiClient client) => _client = client;

        [HttpPost]
        [Route("summy")]
        public string Summy([FromBody] SummyApiModel summy)
        {
            var summyData = _client.Summarization.SummyLuhn(summy.Text, summy.LineQuantity);
            return summyData.Text;
        }
    }
}
