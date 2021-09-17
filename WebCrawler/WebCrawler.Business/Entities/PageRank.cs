using System;

namespace WebCrawler.Business.Entities
{
    public class PageRank
    {
        public PageRank(Guid pageUrlId)
        {
            PageUrlId = pageUrlId;
        }

        public PageRank(Guid pageUrlId, float ponctuation) : this(pageUrlId)
        {
            Ponctuation = ponctuation;
        }
        public Guid PageUrlId { get; set; }
        public PageUrl PageUrl { get; set; }
        public float Ponctuation { get; set; }
        public DateTime LastRanking { get; set; }

        public void SetLastRankingToNow()
        {
            LastRanking = DateTime.UtcNow;
        }
    }
}
