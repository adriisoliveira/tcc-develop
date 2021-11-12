using APIController.Business.Entity.Logs;

namespace APIController.Business.Interfaces.Repository.Logs
{
    public interface IApiTokenLogRepository
    {
        ApiTokenLog Add(ApiTokenLog log);
    }
}
