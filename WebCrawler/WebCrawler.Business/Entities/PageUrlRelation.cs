using System;

namespace WebCrawler.Business.Entities
{
    public class PageUrlRelation : BaseEntity
    {
        public PageUrlRelation()
        {
            Id = Guid.NewGuid();
        }
        public PageUrlRelation(Guid originId, Guid destinationId)
        {
            PageUrlOriginId = originId;
            PageUrlDestinationId = destinationId;
        }
        public Guid PageUrlOriginId { get; set; }
        public PageUrl PageUrlOrigin { get; set; }
        public Guid PageUrlDestinationId { get; set; }
        public PageUrl PageUrlDestination { get; set; }
    }
}
