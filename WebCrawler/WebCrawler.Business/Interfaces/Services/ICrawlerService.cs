using System;
using System.Collections.Generic;
using WebCrawler.Business.DTO;
using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Services
{
    public interface ICrawlerService
    {
        void CrawlThrough(string url, int maxExecutions, ref int executionCount);
        [Obsolete("Realocar no IPageUrlService")]
        IEnumerable<PageUrl> GetAllPageUrls();

        [Obsolete("Realocar no IPageUrlService")]
        IEnumerable<PageUrl> GetAllPageUrlsToIndex();
        IEnumerable<PageUrlBasicInfoDTO> GetAllPageUrlBasicInfoToIndex();

        IEnumerable<UrlCrawlerQueue> GetAllUrlCrawlerQueue();

        string PopUrlCrawlerQueue();
        UrlCrawlerQueue EnqueueUrl(string url);
    }
}
