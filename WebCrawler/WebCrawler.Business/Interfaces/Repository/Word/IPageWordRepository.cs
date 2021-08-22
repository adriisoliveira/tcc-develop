using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Repository.Word
{
    public interface IPageWordRepository
    {
        void Add(PageWord word);
        void AddLocalization(PageWordLocalization wordLocalization);
    }
}
