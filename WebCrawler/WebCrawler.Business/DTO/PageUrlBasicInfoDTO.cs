using System;

namespace WebCrawler.Business.DTO
{
    public class PageUrlBasicInfoDTO
    {
        public Guid PageUrlId { get; set; }
        public string Url { get; set; }///TODO: avaliar necessidade
        public float PageRankPonctuation { get; set; }
        public DateTime? LastRanking { get; set; }
        public DateTime? LastIndexing { get; set; }///TODO: avaliar necessidade

        #region :: Propriedades auxiliares

        public float PageRankPontcuationDefault { 
            get 
            {
                return PageRankPonctuation <= 0 ? 1 : PageRankPonctuation;    
            } 
        }
        #endregion
    }
}
