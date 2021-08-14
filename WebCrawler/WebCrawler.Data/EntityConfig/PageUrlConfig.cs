using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.Entity
{
    public class PageUrlConfig : IEntityTypeConfiguration<PageUrl>
    {
        public void Configure(EntityTypeBuilder<PageUrl> builder)
        {
            builder.HasKey(e => e.Id).HasName("PageUrlId");
            builder.Property(e => e.Id).IsRequired();
            builder.Property(e => e.Url).IsRequired();
            builder.Property(e => e.Url).HasMaxLength(2048);
        }
    }
}
