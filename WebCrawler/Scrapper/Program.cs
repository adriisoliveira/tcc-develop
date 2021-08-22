using System;
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

            _scrapperService = new ScrapperService(
                new PageUrlRepository(new WebCrawlerDataContext()),
                new PageWordRepository(new WebCrawlerDataContext())
                ); // Injeção de dependência

            _crawlerService = new CrawlerService(new PageUrlRepository(new WebCrawlerDataContext()));// Injeção de dependência
            var pages = _crawlerService.GetAllPageUrlsToIndex(); ///TODO: trazer um DTO

            foreach(var page in pages)
                _scrapperService.IndexPage(page.Url);

            ConsoleUtils.OutputConsole("[Indexer]", "Fim da execução do serviço.", ConsoleColor.Cyan);

            Console.ReadKey();
        }
    }
}
