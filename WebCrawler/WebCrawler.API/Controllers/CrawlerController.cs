using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.API.Controllers
{
    [ApiController]
    [Route("crawler")]
    public class CrawlerController : ControllerBase
    {
        protected ICrawlerService _crawlerService;
        protected IUnitOfWork _uow;

        public CrawlerController(ICrawlerService crawlerService, IUnitOfWork uow)
        {
            _crawlerService = crawlerService;
            _uow = uow;
        }

        /// <summary>
        /// Enfileira uma URL no Crawler
        /// </summary>
        /// <param name="url">URL a ser enfileirada</param>
        [HttpPost]
        [Route("enqueue")]
        public ActionResult EnqueueUrl(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.GetResponse();
            }
            catch
            {
                return BadRequest("URL inválida ou inacessível");
            }

            var result = _crawlerService.EnqueueUrl(url);
            _uow.Commit();

            return Ok();
        }
    }
}
