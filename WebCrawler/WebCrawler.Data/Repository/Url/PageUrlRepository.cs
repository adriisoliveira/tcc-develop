using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCrawler.Business.DTO;
using WebCrawler.Business.Entities;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository.Url
{
    public class PageUrlRepository : BaseRepository<PageUrl>, IPageUrlRepository
    {
        public PageUrlRepository(WebCrawlerDataContext context) : base(context)
        { }

        protected DbSet<PageUrlRelation> DbSetPageUrlRelation => Db.PageUrlRelations;
        protected DbSet<PageRank> DbSetPageRank => Db.PageRanks;
        public void Add(PageUrl url)
        {
            url.PreCreate();
            DbSet.Add(url);
        }

        public void Update(PageUrl url)
        {
            Db.Entry(url).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public bool Exists(string url)
        {
            return DbSet.Any(e => e.Url == url);
        }

        public PageUrl GetByUrl(string url)
        {
            ///TODO: considerar utilizar "Contains" ao invés de "=="
            return DbSet.Include(e => e.Rank).Include(e => e.Words).Include(e => e.RelatedUrls)
                .Where(e => e.Url == url).FirstOrDefault();
        }

        public IEnumerable<PageUrl> GetAll()
        {

            return DbSet.Include(e => e.Words).Include(e => e.RelatedUrls).Include(e => e.Rank).ToList();
        }

        public IEnumerable<PageUrl> GetAllToIndex()
        {
            return DbSet.OrderBy(e => e.LastIndexing).ToList();
        }

        public IEnumerable<PageUrlBasicInfoDTO> GetAllBasicInfo(string searchText)
        {
            var pagesWithSpecifiedWord = DbSet
                .Include(e => e.Words)
                .SelectMany(e => e.Words)
                .Where(e => e.PageWord.Word.Contains(searchText))
                .Select(e => e.PageUrlId);

            var result = DbSet
                .Include(e => e.Rank)
                .Select(e => new PageUrlBasicInfoDTO
                {
                    PageUrlId = e.Id,
                    Title = e.Title,
                    LastIndexing = e.LastIndexing,
                    LastRanking = e.Rank.LastRanking,
                    PageRankPonctuation = e.Rank == null ? 0 : e.Rank.Ponctuation,
                    Url = e.Url
                })
                .OrderByDescending(e => e.PageRankPonctuation)
                .ToList();

            return result.Where(e => pagesWithSpecifiedWord.Contains(e.PageUrlId));
        }

        public Guid? GetPageUrlIdByUrl(string url)
        {
            return DbSet.Where(e => e.Url == url).Select(e => e.Id).FirstOrDefault();
        }
        public IEnumerable<PageUrlBasicInfoDTO> GetAllBasicInfoByIds(IEnumerable<Guid> ids)
        {
            return DbSet
                .Where(e => ids.Contains(e.Id))
                .Select(e => new PageUrlBasicInfoDTO
                {
                    PageUrlId = e.Id,
                    Url = e.Url,
                    PageRankPonctuation = e.Rank.Ponctuation,
                    LastIndexing = e.LastIndexing,
                    LastRanking = e.Rank.LastRanking
                }).ToList();
        }

        #region :: PageUrlPageWord
        ///TODO: isto não deveria estar no seu próprio repositório?
        public void AddWord(PageUrlPageWord urlPageWord)
        {
            urlPageWord.PreCreate();
            Db.PageUrlPageWords.Add(urlPageWord);
        }

        public void RemoveWordRange(IEnumerable<PageUrlPageWord> urlPageWords)
        {
            Db.PageUrlPageWords.RemoveRange(urlPageWords);
        }
        #endregion

        #region :: PageUrlRelation
        public bool RelationExists(Guid firstPageUrlId, Guid secondPageUrlId)
        {
            return DbSetPageUrlRelation.Any(e => (e.PageUrlDestinationId == firstPageUrlId && e.PageUrlOriginId == secondPageUrlId)
            || (e.PageUrlOriginId == firstPageUrlId && e.PageUrlDestinationId == secondPageUrlId));
        }
        public void AddRelation(PageUrlRelation urlRelated)
        {
            urlRelated.PreCreate();
            Db.PageUrlRelations.Add(urlRelated);
        }
        public void RemoveRelationRange(IEnumerable<PageUrlRelation> urlRelations)
        {
            DbSetPageUrlRelation.RemoveRange(urlRelations);
        }
        #endregion

        #region :: PageRank
        public void AddPageRank(PageRank pageRank)
        {
            DbSetPageRank.Add(pageRank);
        }

        public void UpdatePageRank(PageRank pageRank)
        {
            Db.Entry(pageRank).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public PageRank GetPageRankByPageUrlId(Guid pageUrlId)
        {
            return DbSetPageRank
               .Where(e => e.PageUrlId == pageUrlId)
               .FirstOrDefault();
        }

        public PageUrlRankDTO GetPageUrlRankDTOByPageUrlId(Guid pageUrlId)
        {
            var result = GetAllPageUrlRankInternal(new List<Guid> { pageUrlId });
            return result?.FirstOrDefault();
        }

        public IEnumerable<PageUrlRankDTO> GetAllPageUrlRankDTOByPageUrlIds(IEnumerable<Guid> pageUrlIds)
        {
            return GetAllPageUrlRankInternal(pageUrlIds);
        }

        public PageUrlRankDTO GetPageUrlRankDTOByUrl(string url)
        {
            var pageUrlId = GetPageUrlIdByUrl(url).GetValueOrDefault();
            return GetPageUrlRankDTOByPageUrlId(pageUrlId);
        }
        #endregion


        #region :: Métodos privados
        private IEnumerable<PageUrlRankDTO> GetAllPageUrlRankInternal(IEnumerable<Guid> pageUrlIds)
        {
            return DbSet
                .Where(e => pageUrlIds.Contains(e.Id))
                .Select(e => new PageUrlRankDTO
                {
                    PageUrlId = e.Id,
                    Url = e.Url,
                    PageRankPonctuation = e.Rank != null ? e.Rank.Ponctuation : 0,
                    LastIndexing = e.LastIndexing,
                    LastRanking = e.Rank != null ? e.Rank.LastRanking : (DateTime?)null,
                    OutgoingPageUrlIds = e.RelatedUrls
                        .Where(i => i.PageUrlOriginId == e.Id).Select(i => i.PageUrlDestinationId),
                    ReferencedByPageUrlIds = e.RelatedUrls
                        .Where(i => i.PageUrlDestinationId == e.Id).Select(i => i.PageUrlOriginId)
                }).ToList();
        }
        #endregion
    }
}
