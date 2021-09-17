using System;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces.Services;
using WebCrawler.Business.Services;
using WebCrawler.Data.DataContext;
using WebCrawler.Data.Repository.Url;

namespace Crawler
{
    class Program
    {
        private static ICrawlerService _crawlerService;
        static void Main(string[] args)
        {
            ConsoleUtils.OutputConsole("[Crawler]", "Iniciado o serviço.", ConsoleColor.DarkCyan);
            var context = new WebCrawlerDataContext();
            var uow = new UnitOfWork(context);
            _crawlerService = new CrawlerService(new PageUrlRepository(context), uow); // Injeção de dependência
            _crawlerService.CrawlThrough("https://stackoverflow.com/questions/10113244/why-use-icollection-and-not-ienumerable-or-listt-on-many-many-one-many-relatio");

            ConsoleUtils.OutputConsole("[Crawler]", "Fim da execução do serviço.", ConsoleColor.DarkCyan);
            Console.ReadKey();
        }
    }
}
