using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Handle(ExceptionHandlerContext context)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Error(method.DescInfo(), context.Exception);
            var stackTrace = new StackTrace(true);
            logger.Error(stackTrace.DescInfo(), context.Exception);

            //base.Handle(context);
        }
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Error(method.DescInfo()); //logger.Error(method.DescInfo(), context.Exception);

            //return base.HandleAsync(context, cancellationToken);
            return null;
        }
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Error(method.DescInfo()); //logger.Error(method.DescInfo(), context.Exception);

            //return base.ShouldHandle(context);
            return false;
        }
    }
}