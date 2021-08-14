
using Microsoft.EntityFrameworkCore;
using WebCrawler.Business.Entities;
using WebCrawler.Data.Entity;

namespace WebCrawler.Data.DataContext
{
    public class WebCrawlerDataContext : DbContext
    {
        //public WebCrawlerDataContext(DbContextOptions<WebCrawlerDataContext> options) : base(options)
        //{

        //}
        public DbSet<PageUrl> PageUrls { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Initial Catalog=WebCrawlerDb;Persist Security Info=True;User ID=sa1;Password=sa123456;Data Source=DESKTOP-I32JP22";
            optionsBuilder.UseSqlServer(connectionString, e => e.MigrationsAssembly("WebCrawler.Data"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PageUrlConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
