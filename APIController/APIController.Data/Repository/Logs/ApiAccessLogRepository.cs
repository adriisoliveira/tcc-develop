using APIController.Business.Entity.Logs;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Data.DataContext;

namespace APIController.Data.Repository.Logs
{
    public class ApiAccessLogRepository : BaseRepository<ApiAccessLog>, IApiAccessLogRepository
    {
        public ApiAccessLogRepository(APIControllerDataContext dataContext) : base(dataContext) { }

        public ApiAccessLog Add(ApiAccessLog log)
        {
            return DbSet.Add(log).Entity;
        }
    }
}
