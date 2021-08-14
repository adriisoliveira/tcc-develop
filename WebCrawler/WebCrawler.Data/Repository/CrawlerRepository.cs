using Microsoft.EntityFrameworkCore;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository
{
    public class CrawlerRepository : ICrawlerRepository
    {
        private WebCrawlerDataContext _context;

        protected DbSet<PageUrl> DbSet => _context.PageUrls;
        public CrawlerRepository(WebCrawlerDataContext context)
        {
            _context = context;
        }
        public void Add(PageUrl url)
        {
            //url.PreCreate();
            //DbSet.Add(url);
            //_context.SaveChanges();
        }
    }
}
