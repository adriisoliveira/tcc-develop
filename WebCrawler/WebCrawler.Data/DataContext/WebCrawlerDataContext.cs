using Microsoft.EntityFrameworkCore;
using WebCrawler.Business.Entities;
using WebCrawler.Data.EntityConfig;

namespace WebCrawler.Data.DataContext
{
    public class WebCrawlerDataContext : DbContext
    {
        //public WebCrawlerDataContext(DbContextOptions<WebCrawlerDataContext> options) : base(options)
        //{

        //}
        #region :: Tabelas
        public DbSet<PageUrl> PageUrls { get; set; }
        public DbSet<PageUrlPageWord> PageUrlPageWords { get; set; }
        public DbSet<PageUrlRelation> PageUrlRelations { get; set; }
        public DbSet<PageWord> PageWords { get; set; }
        public DbSet<PageWordLocalization> PageWordLocalizations { get; set; }
        public DbSet<PageRank> PageRanks { get; set; }
        public DbSet<UrlCrawlerQueue> UrlCrawlerQueue { get; set; }
        #endregion
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Initial Catalog=WebCrawlerDb;Persist Security Info=True;User ID=sa1;Password=sa123456;Data Source=DESKTOP-I32JP22";
            optionsBuilder.UseSqlServer(connectionString, e => e.MigrationsAssembly("WebCrawler.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PageUrlConfig());
            modelBuilder.ApplyConfiguration(new PageWordConfig());
            modelBuilder.ApplyConfiguration(new PageUrlRelationConfig());
            modelBuilder.ApplyConfiguration(new PageUrlPageWordConfig());
            modelBuilder.ApplyConfiguration(new PageWordLocalizationConfig());
            modelBuilder.ApplyConfiguration(new PageRankConfig());
            modelBuilder.ApplyConfiguration(new UrlCrawlerQueueConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
