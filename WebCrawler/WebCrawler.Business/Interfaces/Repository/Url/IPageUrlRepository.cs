using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Business.Entities;

namespace WebCrawler.Business.Interfaces.Repository.Url
{
    public interface IPageUrlRepository
    {
        void Add(PageUrl url);
        void Update(PageUrl url);
        bool Exists(string url);
        PageUrl GetByUrl(string url);
        IEnumerable<PageUrl> GetAll();
        IEnumerable<PageUrl> GetAllToIndex();

        void AddRelated(PageUrlRelation urlRelated);

        void AddPageUrlPageWord(PageUrlPageWord urlPageWord);
    }
}
