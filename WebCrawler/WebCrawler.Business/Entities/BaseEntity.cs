using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler.Business.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime WhenCreated { get; set; }
        public DateTime? WhenUpdated { get; set; }

        public void PreCreate()
        {
            WhenCreated = DateTime.UtcNow;
        }
    }
}
