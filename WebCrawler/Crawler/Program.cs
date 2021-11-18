using System;
using System.Threading;
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
            var crawlerQueue = new UrlCrawlerQueueRepository(context);

            _crawlerService = new CrawlerService(new PageUrlRepository(context), uow, crawlerQueue); // Injeção de dependência

            var urlQueued = _crawlerService.PopUrlCrawlerQueue();
            var executionCount = 0;
            var maxExecutions = 2;
            while (true)
            {
                if(!string.IsNullOrWhiteSpace(urlQueued))
                {
                    uow.Commit();
                    _crawlerService.CrawlThrough(urlQueued, maxExecutions, ref executionCount);
                    ConsoleUtils.OutputConsole("[Crawler]", string.Format("Encerrando execução após {0} turnos.", maxExecutions), ConsoleColor.Yellow);
                    executionCount = 0;
                }

                ConsoleUtils.OutputConsole("[Crawler]", "Buscando páginas...", ConsoleColor.Cyan);
                Thread.Sleep(7000);

                urlQueued = _crawlerService.PopUrlCrawlerQueue();
            }

            //ConsoleUtils.OutputConsole("[Crawler]", "Fim da execução do serviço.", ConsoleColor.DarkCyan);

            //if (Convert.ToInt32(Console.ReadKey()) == 1)
            //    _crawlerService.CrawlThrough("https://stackoverflow.com/questions/10113244/why-use-icollection-and-not-ienumerable-or-listt-on-many-many-one-many-relatio");


            ConsoleUtils.OutputConsole("[Crawler]", "Fim da execução do serviço.", ConsoleColor.DarkCyan);
            Console.ReadKey();
        }
    }
}
