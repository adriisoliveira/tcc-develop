using Microsoft.EntityFrameworkCore;
using System;
using WebCrawler.Business.Helpers;
using WebCrawler.Business.Interfaces.Services;
using WebCrawler.Business.Services;
using WebCrawler.Data.DataContext;
using WebCrawler.Data.Repository;
using WebCrawler.Data.Repository.Url;

namespace Crawler
{
    class Program
    {
        private static ICrawlerService _crawlerService;
        static void Main(string[] args)
        {
            ConsoleUtils.OutputConsole("[Crawler]", "Iniciado o serviço.", ConsoleColor.DarkCyan);

            _crawlerService = new CrawlerService(new PageUrlRepository(new WebCrawlerDataContext())); // Injeção de dependência
            _crawlerService.CrawlThrough("https://www.youtube.com/watch?v=ipbSwv09dDU&ab_channel=ProgrAmadaMente");

            ConsoleUtils.OutputConsole("[Crawler]", "Fim da execução do serviço.", ConsoleColor.DarkCyan);
            Console.ReadKey();
        }
    }
}
