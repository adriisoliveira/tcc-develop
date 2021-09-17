using System;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository.Word;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository.Word
{
    public class PageWordRepository : BaseRepository<PageWord>, IPageWordRepository
    {
        public PageWordRepository(WebCrawlerDataContext context) : base(context)
        { }
        public void Add(PageWord word)
        {
            word.PreCreate();
            DbSet.Add(word);
        }

        ///TODO: isto não deveria estar no seu próprio repositório?
        public void AddLocalization(PageWordLocalization wordLocalization)
        {
            wordLocalization.PreCreate();
            Db.PageWordLocalizations.Add(wordLocalization);
        }
    }
}
