using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCrawler.Business.Entities;
using WebCrawler.Data.DataContext;

namespace WebCrawler.Data.Repository
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected WebCrawlerDataContext Db { get; private set; }
        protected DbSet<TEntity> DbSet => Db.Set<TEntity>();
        public BaseRepository(WebCrawlerDataContext context)
        {
            Db = context;
        }
    }
}
