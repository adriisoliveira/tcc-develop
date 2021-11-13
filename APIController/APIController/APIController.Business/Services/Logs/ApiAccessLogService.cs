using APIController.Business.Entity.Logs;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Business.Interfaces.Service.Logs;

namespace APIController.Business.Services.Logs
{
    public class ApiAccessLogService : IApiAccessLogService
    {
        protected IApiAccessLogRepository _accessLogRepository;

        public ApiAccessLogService(IApiAccessLogRepository accessLogRepository)
        {
            _accessLogRepository = accessLogRepository;
        }

        public ApiAccessLog Add(ApiAccessLog log)
        {
            return _accessLogRepository.Add(log);
        }
    }
}
