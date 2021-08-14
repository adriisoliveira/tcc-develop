using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces.Repository;
using WebCrawler.Business.Interfaces.Services;

namespace WebCrawler.Business.Services
{
    public class CrawlerService : ICrawlerService
    {
        #region :: Constantes
        private const string CRAWLER_OUTPUT_PREFFIX = "[Crawler]";
        private const int PAGES_LIMIT = 50;
        #endregion

        protected string[] _lastPages;
        protected int _pagesCount;
        protected ICrawlerRepository _crawlerRepository;
        
        public CrawlerService(ICrawlerRepository crawlerRepository)
        {
            _lastPages = new string[10];
            _pagesCount = 0;
            _crawlerRepository = crawlerRepository;
        }

        public void CrawlThrough(string url)
        {
            try
            {
                _pagesCount++;
                if (_pagesCount >= PAGES_LIMIT)
                    return;

                var urlBase = UrlConformer(url);

                if (_lastPages.Contains(urlBase))
                    return;

                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Acessando a página \"{0}\".", urlBase);
                LastPagesManage(urlBase);

                //Salva em banco
                _crawlerRepository.Add(new PageUrl(urlBase));

                string page = new WebClient().DownloadString(urlBase);
                var htmlDoc = new HtmlDocument();

                htmlDoc.LoadHtml(page);

                var anchors = htmlDoc
                    .DocumentNode
                    .SelectNodes("//a")?
                    .Where(e => e.Attributes["href"] != null && !e.Attributes["href"].Value.StartsWith("#")
                        && (e.Attributes["href"].Value.StartsWith("https://") || e.Attributes["href"].Value.StartsWith("http://")));

                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Encerrado o acesso à página \"{0}\".", ConsoleColor.Yellow, urlBase);

                if (anchors?.Any() ?? false)
                    foreach (var a in anchors.Where(e => !_lastPages.Contains(e.Attributes["href"].Value.Trim('/'))))
                    {
                        var link = a.Attributes["href"];
                        
                        if (link.Value.StartsWith("/"))
                            CrawlThrough(string.Format("{0}{1}", urlBase, link.Value)); //Links pro mesmo site
                        else
                            CrawlThrough(link.Value); //Links externos
                    }
            }
            catch (Exception e)
            {
                ConsoleUtils.OutputConsole(CRAWLER_OUTPUT_PREFFIX, "Erro ao acessar a página \"{0}\". \nDetalhes do erro: {1}", ConsoleColor.Red, url, e.Message);
            }
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
        private string UrlConformer(string unformattedUrl)
        {
            var uri = new Uri(unformattedUrl);
            return (uri.Scheme + "://" + uri.Host + uri.PathAndQuery + uri.Fragment).Trim('/');
        }
        #endregion
    }
}
