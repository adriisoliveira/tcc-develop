using System;
using System.Collections.Generic;

namespace WebCrawler.Business.DTO
{
    /// <summary>
    /// DTO exclusiva para o uso no método PageRank - ScrapperService
    /// </summary>
    public class PageUrlRankDTO : PageUrlBasicInfoDTO
    {
        /// <summary>
        /// IDs das URLs para as quais a página em questão aponta
        /// </summary>
        public IEnumerable<Guid> OutgoingPageUrlIds { get; set; }
        /// <summary>
        /// IDs das URLs que apontam para a página em questão
        /// </summary>
        public IEnumerable<Guid> ReferencedByPageUrlIds { get; set; }
    }
}
