using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Repository
{
    public interface ICrawlerRepository
    {
        void Add(PageUrl url);
    }
}
