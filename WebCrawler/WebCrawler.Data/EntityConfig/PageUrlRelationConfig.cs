using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebCrawler.Business.Entities;

namespace WebCrawler.Data.EntityConfig
{
    public class PageUrlRelationConfig : IEntityTypeConfiguration<PageUrlRelation>
    {
        public void Configure(EntityTypeBuilder<PageUrlRelation> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PageUrlRelationId");
            builder.Property(e => e.PageUrlDestinationId).IsRequired();
            builder.Property(e => e.PageUrlOriginId).IsRequired();

        }
    }
}
