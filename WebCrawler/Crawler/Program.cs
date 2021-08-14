using Microsoft.EntityFrameworkCore;
using System;
using WebCrawler.Business.Interfaces.Services;
using WebCrawler.Business.Services;
using WebCrawler.Data.DataContext;
using WebCrawler.Data.Repository;

namespace Crawler
{
    class Program
    {
        private static ICrawlerService _business;
        static void Main(string[] args)
        {
            Console.WriteLine("[Crawler] Iniciado o serviço de Crawler");

            _business = new CrawlerService(new CrawlerRepository(new WebCrawlerDataContext())); // Injeção de dependência
            _business.CrawlThrough("https://www.youtube.com/watch?v=ipbSwv09dDU&ab_channel=ProgrAmadaMente");

            Console.ReadKey();
        }
    }
}
