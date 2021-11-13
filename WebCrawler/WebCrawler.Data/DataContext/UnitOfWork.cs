using WebCrawler.Business.Interfaces;

namespace WebCrawler.Data.DataContext
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly WebCrawlerDataContext _context;
        public UnitOfWork(WebCrawlerDataContext context)
        {
            _context = context;
        }
        public void Commit() => _context.SaveChanges();

        public void Rollback()
        {
            //
        }
    }
}
