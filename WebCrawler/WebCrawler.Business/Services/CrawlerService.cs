using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebCrawler.Business.DTO;
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
        private const int PAGES_LIMIT = 500;
        #endregion

        protected string[] _lastPages;
        protected int _pagesCount;
        protected IPageUrlRepository _urlRepository;
        protected IUrlCrawlerQueueRepository _urlCrawlerQueueRepository;
        protected IUnitOfWork _uow;
        public CrawlerService(IPageUrlRepository urlRepository, IUnitOfWork uow, IUrlCrawlerQueueRepository urlCrawlerQueueRepository)
        {
            _lastPages = new string[10];
            _pagesCount = 0;
            _urlRepository = urlRepository;
            _uow = uow;
            _urlCrawlerQueueRepository = urlCrawlerQueueRepository;
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

        public void CrawlThrough(string urlBase, int maxExecutions, ref int executionCount)
        {
            try
            {
                executionCount++;
                if (executionCount > maxExecutions)
                    return;

                var url = TextFormattingUtils.UrlConformer(urlBase);
                _pagesCount++;
                
                if (_pagesCount >= PAGES_LIMIT || !ValidateUrlToCrawler(url))
                {
                    ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, url);
                    return;
                }

                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Acessando a página \"{0}\".", url);
                LastPagesManage(url);

                string page = new WebClient().DownloadString(url);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);
                
                var pageTitle = htmlDoc.DocumentNode.SelectSingleNode("//title").InnerText;

                //Salva em banco
                if (!_urlRepository.Exists(url))
                    _urlRepository.Add(new PageUrl(pageTitle, url));

                //TODO: avaliar a possibilidade de pegar apenas dominios externos após uma certa quantidade de iteração
                var pageLinks = HTMLDocHelper.GetHtmlDocumentLinks(htmlDoc);

                _uow.Commit();
                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, url);

                if (pageLinks?.Any() ?? false)
                    foreach (var pageLink in pageLinks.Where(e => !_lastPages.Contains(e)))
                    {
                        if (pageLink.StartsWith("/"))
                            CrawlThrough(string.Format("{0}{1}", url, pageLink), maxExecutions, ref executionCount); //Links pro mesmo site
                        else
                            CrawlThrough(pageLink, maxExecutions, ref executionCount); //Links externos
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

        public IEnumerable<PageUrlBasicInfoDTO> GetAllPageUrlBasicInfoToIndex()
        {
            return _urlRepository.GetAllBasicInfoToIndex();
        }

        public IEnumerable<UrlCrawlerQueue> GetAllUrlCrawlerQueue()
        {
            return _urlCrawlerQueueRepository.GetAll();
        }

        public string PopUrlCrawlerQueue()
        {
            return _urlCrawlerQueueRepository.PopUrlCrawlerQueue();
        }

        public UrlCrawlerQueue EnqueueUrl(string url)
        {
            var urlToQueue = new UrlCrawlerQueue(url);
            urlToQueue.WhenQueued = DateTime.UtcNow;

            return _urlCrawlerQueueRepository.Add(urlToQueue);
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
