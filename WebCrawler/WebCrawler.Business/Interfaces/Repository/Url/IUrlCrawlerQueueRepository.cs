using System;
using System.Collections.Generic;
using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Repository.Url
{
    public interface IUrlCrawlerQueueRepository
    {
        UrlCrawlerQueue Add(UrlCrawlerQueue url);
        IEnumerable<UrlCrawlerQueue> GetAll();
        string PopUrlCrawlerQueue();
    }
}
