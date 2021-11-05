using APIController.Business.Entity.Logs;

namespace APIController.Business.Interfaces.Repository.Logs
{
    public interface IApiAccessLogRepository
    {
        ApiAccessLog Add(ApiAccessLog log);
    }
}
