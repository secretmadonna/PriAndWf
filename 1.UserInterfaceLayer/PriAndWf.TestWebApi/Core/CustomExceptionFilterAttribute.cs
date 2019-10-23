using log4net;
using PriAndWf.Infrastructure.Extension;
using System;
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
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.ErrorFormat("{0}{1}{2}{3}", method.DescInfo(), Environment.NewLine, actionExecutedContext.Exception.ToString(), Environment.NewLine);

            base.OnException(actionExecutedContext);
        }
        public override Task OnExceptionAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            return base.OnExceptionAsync(actionExecutedContext, cancellationToken);
        }
    }
}