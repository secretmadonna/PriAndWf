using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Error(method.DescInfo(), actionExecutedContext.Exception);
            var stackTrace = new StackTrace(true);
            logger.Error(stackTrace.DescInfo(), actionExecutedContext.Exception);

            base.OnException(actionExecutedContext);
        }
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Error(method.DescInfo()); //logger.Error(method.DescInfo(), actionExecutedContext.Exception);

            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}