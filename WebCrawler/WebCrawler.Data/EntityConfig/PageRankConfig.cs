using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageRankConfig : IEntityTypeConfiguration<PageRank>
    {
        public void Configure(EntityTypeBuilder<PageRank> builder)
        {
            builder.HasKey(e => e.PageUrlId);
            builder.Property(e => e.PageUrlId).HasColumnName("PageUrlId");
        }
    }
}
