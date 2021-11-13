using APIController.Business.Entity.Logs;
using APIController.Business.Interfaces;
using APIController.Business.Interfaces.Repository.Logs;
using APIController.Data.Repository.Logs;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace APIController.Annotations
{
    public class RegisterAccessLog : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var ip = filterContext.HttpContext.Connection.RemoteIpAddress.ToString();
            var userAgent = filterContext.HttpContext.Request.Headers["User-Agent"].ToString();
            var actionDescriptorSplitted = filterContext.ActionDescriptor?.DisplayName.Split('.');

            var action = string.Join('.', actionDescriptorSplitted.Skip(2));

            var repository = filterContext.HttpContext.RequestServices.GetService<IApiAccessLogRepository>();
            var uow = filterContext.HttpContext.RequestServices.GetService<IUnitOfWork>();

            repository.Add(new ApiAccessLog(ip, userAgent, action, DateTime.UtcNow));
            uow.Commit();

            base.OnActionExecuted(filterContext);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}
