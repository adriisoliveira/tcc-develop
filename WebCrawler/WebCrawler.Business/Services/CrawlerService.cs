using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class CrawlerService : ICrawlerService
    {
        #region :: Constantes
        private const string CRAWLER_OUTPUT_PREFFIX = "[Crawler]";
        private const int PAGES_LIMIT = 200;
        #endregion

        protected string[] _lastPages;
        protected int _pagesCount;
        protected IPageUrlRepository _urlRepository;
        protected IUnitOfWork _uow;
        public CrawlerService(IPageUrlRepository urlRepository, IUnitOfWork uow)
        {
            _lastPages = new string[10];
            _pagesCount = 0;
            _urlRepository = urlRepository;
            _uow = uow;
        }

        private bool ValidateUrlToCrawler(string url)
        {
            if (_lastPages.Contains(url))
                return false;

            var urlSplittedByBar = url.Split('/');
            if (urlSplittedByBar.Count() > urlSplittedByBar.Distinct().Count() + 1)            
                return false;

            return true;
        }

        public void CrawlThrough(string urlBase)
        {
            try
            {
                var url = TextFormattingUtils.UrlConformer(urlBase);
                _pagesCount++;
                
                if (_pagesCount >= PAGES_LIMIT || !ValidateUrlToCrawler(url))
                {
                    ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, url);
                    return;
                }

                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Acessando a página \"{0}\".", url);
                LastPagesManage(url);

                //Salva em banco
                if(!_urlRepository.Exists(url))
                    _urlRepository.Add(new PageUrl(url));

                string page = new WebClient().DownloadString(url);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);
                
                //TODO: avaliar a possibilidade de pegar apenas dominios externos após uma certa quantidade de iteração
                var pageLinks = HTMLDocHelper.GetHtmlDocumentLinks(htmlDoc);

                _uow.Commit();
                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, url);

                if (pageLinks?.Any() ?? false)
                    foreach (var pageLink in pageLinks.Where(e => !_lastPages.Contains(e)))
                    {
                        if (pageLink.StartsWith("/"))
                            CrawlThrough(string.Format("{0}{1}", url, pageLink)); //Links pro mesmo site
                        else
                            CrawlThrough(pageLink); //Links externos
                    }
            }
            catch (Exception e)
            {
                _uow.Rollback();
                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Erro ao acessar a página \"{0}\". \nDetalhes do erro: {1}", ConsoleColor.Red, urlBase, e.Message);
            }
        }

        public IEnumerable<PageUrl> GetAllPageUrls()
        {
            return _urlRepository.GetAll();
        }

        public IEnumerable<PageUrl> GetAllPageUrlsToIndex()
        {
            return _urlRepository.GetAllToIndex();
        }
        #region :: Métodos Privados
        private void LastPagesManage(string url)
        {
            var lastPagesCount = _lastPages.Where(e => e != null).Count();
            if (lastPagesCount == 10)
            {
                lastPagesCount = 0;
                _lastPages = new string[10];
            }

            _lastPages[lastPagesCount] = url.Trim('/');
        }
        #endregion
    }
}
