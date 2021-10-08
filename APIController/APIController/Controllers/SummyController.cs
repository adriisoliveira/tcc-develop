using APIController.Models.Summarization;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("summarization")]
    public class SummyController : BaseController
    {
        protected IApiClient _client;
        public SummyController(IApiClient client) => _client = client;

        [HttpPost]
        [Route("summy")]
        public HttpResponseMessage Summy([FromBody] SummyApiModel summy)
        {
            var summyData = _client.Summarization.SummyLuhn(summy.Text, summy.LineQuantity);
            return Request.CreateResponse(HttpStatusCode.OK, summyData.Text);
        }
    }
}
