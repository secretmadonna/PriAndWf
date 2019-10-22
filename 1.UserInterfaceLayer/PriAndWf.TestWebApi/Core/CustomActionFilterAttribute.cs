using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            base.OnActionExecuted(actionExecutedContext);
        }
        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            return base.OnActionExecutedAsync(actionExecutedContext, cancellationToken);
        }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            base.OnActionExecuting(actionContext);
        }
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}