using APIController.Business.Entity.Logs;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Data.DataContext;

namespace APIController.Data.Repository.Logs
{
    public class ApiTokenLogRepository : BaseRepository<ApiTokenLog>, IApiTokenLogRepository
    {
        public ApiTokenLogRepository(APIControllerDataContext dataContext) : base(dataContext) { }

        public ApiTokenLog Add(ApiTokenLog log)
        {
            return DbSet.Add(log).Entity;
        }
    }
}
