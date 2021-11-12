using System;

namespace WebCrawler.Business.DTO
{
    public class PageUrlBasicInfoDTO
    {
        public Guid PageUrlId { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public float PageRankPonctuation { get; set; }
        public DateTime? LastRanking { get; set; }
        public DateTime? LastIndexing { get; set; }///TODO: avaliar necessidade

        #region :: Propriedades auxiliares

        public float PageRankPontcuationDefault { 
            get 
            {
                return PageRankPonctuation <= 0 ? 0 : PageRankPonctuation;    
            } 
        }
        #endregion
    }
}
