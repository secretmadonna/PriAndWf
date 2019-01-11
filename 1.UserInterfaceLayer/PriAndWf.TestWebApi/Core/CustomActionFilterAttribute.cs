using log4net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            //actionExecutedContext.Response.Content.
            exceptionLogger.Info("CustomActionFilterAttribute.OnActionExecuted");
            base.OnActionExecuted(actionExecutedContext);
        }
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            exceptionLogger.Info("CustomActionFilterAttribute.OnActionExecutedAsync");
            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            exceptionLogger.Info("CustomActionFilterAttribute.OnActionExecuting");
            base.OnActionExecuting(actionContext);
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            exceptionLogger.Info("CustomActionFilterAttribute.OnActionExecutingAsync");
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}