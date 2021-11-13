using System;

namespace WebCrawler.Business.Entities
{
    public class UrlCrawlerQueue : BaseEntity
    {
        public UrlCrawlerQueue()
        {
            Id = Guid.NewGuid();
        }

        public UrlCrawlerQueue(string url) : this()
        {
            Url = url;
        }

        public string Url { get; set; }

        public DateTime WhenQueued { get; set; }
    }
}
