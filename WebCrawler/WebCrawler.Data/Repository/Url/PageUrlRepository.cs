using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository.Url
{
    public class PageUrlRepository : BaseRepository<PageUrl>, IPageUrlRepository
    {
        public PageUrlRepository(WebCrawlerDataContext context) : base(context)
        { }
        public void Add(PageUrl url)
        {
            url.PreCreate();
            DbSet.Add(url);
            Db.SaveChanges();
        }

        public void Update(PageUrl url)
        {
            Db.Entry(url).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();
        }

        public bool Exists(string url)
        {
            return DbSet.Any(e => e.Url == url);
        }

        public PageUrl GetByUrl(string url)
        {
            ///TODO: considerar utilizar "Contains" ao invés de "=="
            return DbSet.Where(e => e.Url == url).FirstOrDefault();
        }

        public IEnumerable<PageUrl> GetAll()
        {
            return DbSet.ToList();
        }

        public IEnumerable<PageUrl> GetAllToIndex()
        {
            return DbSet.OrderBy(e => e.LastIndexing).ToList();
        }
        public void AddRelated(PageUrlRelation urlRelated)
        {
            Db.PageUrlRelations.Add(urlRelated);
            Db.SaveChanges();
        }

        ///TODO: isto não deveria estar no seu próprio repositório?
        public void AddPageUrlPageWord(PageUrlPageWord urlPageWord)
        {
            urlPageWord.PreCreate();
            Db.PageUrlPageWords.Add(urlPageWord);
            Db.SaveChanges();
        }
    }
}
