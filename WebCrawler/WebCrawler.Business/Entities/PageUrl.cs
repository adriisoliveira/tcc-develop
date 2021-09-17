using System;
using System.Collections.Generic;

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

        public DateTime? LastIndexing { get; set; }
        public ICollection<PageUrlRelation> RelatedUrls { get; set; }
        public ICollection<PageUrlPageWord> Words { get; set; }

        public PageRank Rank { get; set; }
    }
}
