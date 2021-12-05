using APIController.Business.Interfaces.Service.Users;
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
    public class WebPagesController : BaseController
    {
        protected IApiClient _client;
        protected string _crawlerHost;
        public WebPagesController(IApiClient client, IConfiguration configuration, IUserService userService)
            : base(userService)
        {
            _client = client;
            _crawlerHost = configuration.GetSection("ClientConnections:Crawler")["Host"];
        }

        /// <summary>
        /// Retorna todas as páginas que contenham o texto pesquisado (ranqueadas)
        /// </summary>
        /// <param name="search">Pesquisa por texto</param>
        [HttpGet]
        [Route("get/{search}")]
        public  List<ApiWebPageBasicInfo> GetWebPages(string search)
        {
            using (var client = new HttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(string.Format("{0}/pages/search?searchText={1}", _crawlerHost, search))
                };

                request.Headers.Add("Access-Control-Allow-Origin", "*");

                var responseContent = client.SendAsync(request).Result;
                var requestResult = responseContent.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<List<ApiWebPageBasicInfo>>(requestResult);
                return result;
            }
        }

    }
}
