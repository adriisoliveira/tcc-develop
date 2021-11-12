using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class UrlCrawlerQueueConfig : IEntityTypeConfiguration<UrlCrawlerQueue>
    {
        public void Configure(EntityTypeBuilder<UrlCrawlerQueue> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("UrlCrawlerQueueId").IsRequired();
        }
    }
}
