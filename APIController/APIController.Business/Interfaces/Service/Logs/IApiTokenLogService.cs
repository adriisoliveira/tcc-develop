using APIController.Business.Entity.Logs;

namespace APIController.Business.Interfaces.Service.Logs
{
    public interface IApiTokenLogService
    {
        ApiTokenLog Add(ApiTokenLog log);
    }
}
