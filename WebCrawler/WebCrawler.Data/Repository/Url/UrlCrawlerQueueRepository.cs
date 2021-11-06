using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository.Url
{
    public class UrlCrawlerQueueRepository : BaseRepository<UrlCrawlerQueue>, IUrlCrawlerQueueRepository
    {
        public UrlCrawlerQueueRepository(WebCrawlerDataContext context) : base(context) { }

        public UrlCrawlerQueue Add(UrlCrawlerQueue url)
        {
            url.PreCreate();
            return DbSet.Add(url).Entity;
        }

        public IEnumerable<UrlCrawlerQueue> GetAll()
        {
            return DbSet.ToList();
        }

        public string PopUrlCrawlerQueue()
        {
            var queueItem = DbSet
                .OrderBy(e => e.WhenQueued)
                .Where(e => !string.IsNullOrWhiteSpace(e.Url))
                .FirstOrDefault();

            if (queueItem == null)
                return null;

            var result = queueItem.Url;

            DbSet.Remove(queueItem);

            return result;
        }


    }
}
