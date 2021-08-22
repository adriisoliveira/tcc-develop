using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageUrlPageWordConfig : IEntityTypeConfiguration<PageUrlPageWord>
    {
        public void Configure(EntityTypeBuilder<PageUrlPageWord> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PageUrlPageWordId");
            builder.Property(e => e.PageUrlId).IsRequired();
            builder.Property(e => e.PageWordId).IsRequired();
        }
    }
}
