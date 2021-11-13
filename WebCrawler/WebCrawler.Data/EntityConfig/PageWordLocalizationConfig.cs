using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageWordLocalizationConfig : IEntityTypeConfiguration<PageWordLocalization>
    {
        public void Configure(EntityTypeBuilder<PageWordLocalization> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PageWordLocalizationId").IsRequired();
            builder.Property(e => e.PageUrlId).IsRequired();
            builder.Property(e => e.PageWordId).IsRequired();
            builder.Property(e => e.Localization).IsRequired();
        }
    }
}
