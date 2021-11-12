using System;

namespace WebCrawler.Business.Entities
{
    public class PageUrlPageWord : BaseEntity
    {
        public PageUrlPageWord()
        {
            Id = Guid.NewGuid();
        }

        public PageUrlPageWord(Guid pageUrlId, Guid pageWordId) : this()
        {
            PageUrlId = pageUrlId;
            PageWordId = pageWordId;
        }

        public Guid PageUrlId { get; set; }
        public PageUrl PageUrl { get; set; }
        public Guid PageWordId { get; set; }
        public PageWord PageWord { get; set; }
        public DateTime? WhenUpdated { get; set; }
    }
}
