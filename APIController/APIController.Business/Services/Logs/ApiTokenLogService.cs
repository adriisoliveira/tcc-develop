using APIController.Business.Entity.Logs;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Business.Interfaces.Service.Logs;

namespace APIController.Business.Services.Logs
{
    public class ApiTokenLogService : IApiTokenLogService
    {
        protected IApiTokenLogRepository _tokenLogRepository;

        public ApiTokenLogService(IApiTokenLogRepository tokenLogRepository)
        {
            _tokenLogRepository = tokenLogRepository;
        }

        public ApiTokenLog Add(ApiTokenLog log)
        {
            return _tokenLogRepository.Add(log);
        }
    }
}
