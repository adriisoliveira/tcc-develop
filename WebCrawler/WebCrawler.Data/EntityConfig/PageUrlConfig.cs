using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageUrlConfig : IEntityTypeConfiguration<PageUrl>
    {
        public void Configure(EntityTypeBuilder<PageUrl> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PageUrlId");
            builder.Property(e => e.Url).IsRequired().HasMaxLength(2048);

            builder.HasMany(e => e.RelatedUrls).WithOne(e => e.PageUrlOrigin).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
