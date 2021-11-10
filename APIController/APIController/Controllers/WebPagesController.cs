using APIController.Models.WebPages;
using APISummarizationClient.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace APIController.Controllers
{
    [Authorize()]
    [ApiController]
    [Route("webpages")]
<<<<<<< HEAD
    public class WebPagesController : ControllerBase
=======
    public class WebPagesController : BaseController
>>>>>>> feature/develop/TCC-37-API_Controller_new
    {
        protected IApiClient _client;
        protected string _crawlerHost;
        public WebPagesController(IApiClient client, IConfiguration configuration)
        {
            _client = client;
            _crawlerHost = configuration.GetSection("ClientConnections:Crawler")["Host"];
        }

        /// <summary>
        /// Retorna todas as páginas que contenham o texto pesquisado (ranqueadas)
        /// </summary>
        /// <param name="search">Pesquisa por texto</param>
<<<<<<< HEAD
        /// <param name="max">Máximo de valores a serem retornados</param>
        [HttpGet]
        [Route("get/{search}")]
        public List<ApiWebPageBasicInfo> GetWebPages(string search, int max)
=======
        [HttpGet]
        [Route("get/{search}")]
        public  List<ApiWebPageBasicInfo> GetWebPages(string search)
>>>>>>> feature/develop/TCC-37-API_Controller_new
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
<<<<<<< HEAD
                    RequestUri = new Uri(string.Format("{0}/pages/search?searchText={1}&max={2}", _crawlerHost, search, max))
=======
                    RequestUri = new Uri(string.Format("{0}/pages/search?searchText={1}", _crawlerHost, search))
>>>>>>> feature/develop/TCC-37-API_Controller_new
                };

                request.Headers.Add("Access-Control-Allow-Origin", "*");

                var responseContent = client.SendAsync(request).Result;
                var requestResult = responseContent.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<ApiWebPageBasicInfo>>(requestResult);
<<<<<<< HEAD
                return result.OrderByDescending(e => e.PageRankPonctuation).ToList();
=======
                return result;
>>>>>>> feature/develop/TCC-37-API_Controller_new
            }
        }

    }
}
