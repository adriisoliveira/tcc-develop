using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageWordConfig : IEntityTypeConfiguration<PageWord>
    {
        public void Configure(EntityTypeBuilder<PageWord> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PageWordId").IsRequired();
            builder.Property(e => e.Word).HasMaxLength(200).IsRequired();
        }
    }
}
