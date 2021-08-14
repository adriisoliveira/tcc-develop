using System;

namespace WebCrawler.Business.Entities
{
    public class PageUrl : BaseEntity
    {
        public PageUrl()
        {
            Id = Guid.NewGuid();
        }
        public PageUrl(string url) : this()
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
