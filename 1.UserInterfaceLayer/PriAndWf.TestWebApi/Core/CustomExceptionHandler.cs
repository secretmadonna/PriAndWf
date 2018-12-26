using log4net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionHandler : ExceptionHandler
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void Handle(ExceptionHandlerContext context)
        {
            exceptionLogger.Error("CustomExceptionHandler.Handle", context.Exception);
            base.Handle(context);
        }
        public override Task HandleAsync(ExceptionHandlerContext context, CancellationToken cancellationToken)
        {
            exceptionLogger.Error("CustomExceptionHandler.HandleAsync", context.Exception);
            return base.HandleAsync(context, cancellationToken);
        }
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            exceptionLogger.Error("CustomExceptionHandler.ShouldHandle", context.Exception);
            return base.ShouldHandle(context);
        }
    }
}