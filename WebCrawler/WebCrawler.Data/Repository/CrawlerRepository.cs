using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository
{
    [Obsolete("ISSO DEVE VIRAR PAGEURLREPOSITORY")]
    public class CrawlerRepository : ICrawlerRepository
    {
        private WebCrawlerDataContext _context;

        protected DbSet<PageUrl> DbSet => _context.PageUrls;
        public CrawlerRepository(WebCrawlerDataContext context)
        {
            _context = context;
        }
        
    }
}
