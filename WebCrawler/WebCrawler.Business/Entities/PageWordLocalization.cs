using System;

namespace WebCrawler.Business.Entities
{
    public class PageWordLocalization : BaseEntity
    {
        public PageWordLocalization()
        {
            Id = Guid.NewGuid();
        }

        public PageWordLocalization(Guid pageWordId, Guid pageUrlId, int localization) : this()
        {
            PageWordId = pageWordId;
            PageUrlId = pageUrlId;
            Localization = localization;
        }

        public Guid PageWordId { get; set; }
        public PageWord PageWord { get; set; }
        public Guid PageUrlId { get; set; }
        public PageUrl PageUrl { get; set; }

        public int Localization { get; set; }
    }
}
