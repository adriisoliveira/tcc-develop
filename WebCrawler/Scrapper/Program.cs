using System;
using System.Linq;
using System.Threading;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces.Services;
using WebCrawler.Business.Services;
using WebCrawler.Data.DataContext;
using WebCrawler.Data.Repository.Url;
using WebCrawler.Data.Repository.Word;

namespace Scraper
{
    class Program
    {
        private static IScrapperService _scrapperService;
        private static ICrawlerService _crawlerService;
        public static void Main(string[] args)
        {
            ConsoleUtils.OutputConsole("[Indexer]", "Iniciado o serviço.", ConsoleColor.Cyan);
            var context = new WebCrawlerDataContext();
            var uow = new UnitOfWork(context);
            var crawlerQueue = new UrlCrawlerQueueRepository(context);

            _scrapperService = new ScrapperService(
                new PageUrlRepository(context),
                new PageWordRepository(context),
                new UnitOfWork(context)
                ); // Injeção de dependência

            _crawlerService = new CrawlerService(new PageUrlRepository(context), uow, crawlerQueue);// Injeção de dependência
            
            var pages = _crawlerService.GetAllPageUrlBasicInfoToIndex();
            while (true)
            {
                if(pages?.Any() ?? false)
                    for (int i = 0; i < pages.Count(); i++)
                        _scrapperService.IndexPage(pages.ElementAt(i).Url);
                
                ConsoleUtils.OutputConsole("[Indexer]", "Buscando páginas para indexação...", ConsoleColor.Cyan);
                Thread.Sleep(7000);

                pages = _crawlerService.GetAllPageUrlBasicInfoToIndex();
            }

            //foreach (var page in pages)
            //    _scrapperService.PageRank(page.Url);

            //ConsoleUtils.OutputConsole("[Indexer]", "Fim da execução do serviço.", ConsoleColor.Cyan);

            //Console.ReadKey();
        }
    }
}
