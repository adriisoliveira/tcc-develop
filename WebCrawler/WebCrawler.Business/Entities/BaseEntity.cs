using System;

namespace WebCrawler.Business.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }

        public void PreCreate()
        {
            WhenCreated = DateTime.UtcNow;
        }
    }
}
