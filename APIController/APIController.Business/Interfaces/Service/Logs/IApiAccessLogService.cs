using APIController.Business.Entity.Logs;

namespace APIController.Business.Interfaces.Service.Logs
{
    public interface IApiAccessLogService
    {
        ApiAccessLog Add(ApiAccessLog log);
    }
}
