using System.Collections.Generic;
using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Services
{
    public interface ICrawlerService
    {
        void CrawlThrough(string url);

        IEnumerable<PageUrl> GetAllPageUrls();
        IEnumerable<PageUrl> GetAllPageUrlsToIndex();
    }
}
