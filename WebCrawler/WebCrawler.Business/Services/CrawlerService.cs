using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class CrawlerService : ICrawlerService
    {
        #region :: Constantes
        private const string CRAWLER_OUTPUT_PREFFIX = "[Crawler]";
        private const int PAGES_LIMIT = 50;
        #endregion

        protected string[] lastPages;
        protected int pagesCount;
        protected IPageUrlRepository _urlRepository;

        public CrawlerService(IPageUrlRepository urlRepository)
        {
            lastPages = new string[10];
            pagesCount = 0;
            _urlRepository = urlRepository;
        }

        public void CrawlThrough(string urlBase)
        {
            try
            {
                pagesCount++;
                if (pagesCount >= PAGES_LIMIT)
                    return;

                var url = TextFormattingUtils.UrlConformer(urlBase);

                if (lastPages.Contains(url) || _urlRepository.Exists(url))
                    return;
                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Acessando a página \"{0}\".", url);
                LastPagesManage(url);

                //Salva em banco
                _urlRepository.Add(new PageUrl(url));

                string page = new WebClient().DownloadString(url);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                var anchors = htmlDoc
                    .DocumentNode
                    .SelectNodes("//a")?
                    .Where(e => e.Attributes["href"] != null && !e.Attributes["href"].Value.StartsWith("#")
                        && (e.Attributes["href"].Value.StartsWith("https://") || e.Attributes["href"].Value.StartsWith("http://")));

                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, url);

                if (anchors?.Any() ?? false)
                    foreach (var a in anchors.Where(e => !lastPages.Contains(e.Attributes["href"].Value.Trim('/'))))
                    {
                        var link = a.Attributes["href"];

                        if (link.Value.StartsWith("/"))
                            CrawlThrough(string.Format("{0}{1}", url, link.Value)); //Links pro mesmo site
                        else
                            CrawlThrough(link.Value); //Links externos
                    }
            }
            catch (Exception e)
            {
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
            var lastPagesCount = lastPages.Where(e => e != null).Count();
            if (lastPagesCount == 10)
            {
                lastPagesCount = 0;
                lastPages = new string[10];
            }

            lastPages[lastPagesCount] = url.Trim('/');
        }
        #endregion
    }
}
