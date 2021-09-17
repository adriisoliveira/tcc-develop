using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Business.DTO;
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

        void AddRelation(PageUrlRelation urlRelated);
        void RemoveRelationRange(IEnumerable<PageUrlRelation> urlRelations);

        void AddWord(PageUrlPageWord urlPageWord);
        void RemoveWordRange(IEnumerable<PageUrlPageWord> urlPageWords);

        PageUrlRankDTO GetPageUrlRankDTOByPageUrlId(Guid pageUrlId);
        IEnumerable<PageUrlRankDTO> GetAllPageUrlRankDTOByPageUrlIds(IEnumerable<Guid> pageUrlIds);
        PageUrlRankDTO GetPageUrlRankDTOByUrl(string url);
        IEnumerable<PageUrlBasicInfoDTO> GetAllBasicInfoByIds(IEnumerable<Guid> ids);

        Guid? GetPageUrlIdByUrl(string url);

        bool RelationExists(Guid firstPageUrlId, Guid secondPageUrlId);

        PageRank GetPageRankByPageUrlId(Guid pageUrlId);
        void AddPageRank(PageRank pageRank);
        void UpdatePageRank(PageRank pageRank);
    }
}
