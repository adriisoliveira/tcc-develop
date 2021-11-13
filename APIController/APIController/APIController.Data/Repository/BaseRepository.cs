using APIController.Business.Entity;
using APIController.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace APIController.Data.Repository
{
    public class BaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected APIControllerDataContext Context { get; set; }
        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();
        public BaseRepository(APIControllerDataContext dataContext)
        {
            Context = dataContext;
        }
    }
}
