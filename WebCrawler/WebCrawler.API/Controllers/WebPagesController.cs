using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Business.DTO;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.API.Controllers
{
    [ApiController]
    [Route("pages")]
    public class WebPagesController : ControllerBase
    {
        protected ICrawlerService _crawlerService;
        protected IPageUrlService _pageUrlService;
        public WebPagesController(ICrawlerService crawlerService, IPageUrlService pageUrlService)
        {
            _crawlerService = crawlerService;
            _pageUrlService = pageUrlService;
        }

        /// <summary>
        /// Retorna uma lista de links e informações de páginas de acordo com o texto informado
        /// </summary>
        /// <param name="searchText">Texto de pesquisa</param>
        /// <param name="max">Máximo de resultados</param>
        [HttpGet]
        [Route("search")]
        public List<PageUrlBasicInfoDTO> SearchForPages(string searchText, int max = 0)
        {
            var result = _pageUrlService.GetAllBasicInfo(searchText);

            return max > 0 ? result.Take(max).ToList() : result.ToList();
        }
    }
}
