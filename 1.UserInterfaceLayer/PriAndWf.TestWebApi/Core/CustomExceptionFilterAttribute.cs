using log4net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            exceptionLogger.Error("CustomExceptionFilterAttribute.OnException", actionExecutedContext.Exception);
            base.OnException(actionExecutedContext);
        }
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            exceptionLogger.Error("CustomExceptionFilterAttribute.OnExceptionAsync", actionExecutedContext.Exception);
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}