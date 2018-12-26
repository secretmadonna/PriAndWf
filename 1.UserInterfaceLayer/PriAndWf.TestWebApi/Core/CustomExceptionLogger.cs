using log4net;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionLogger : ExceptionLogger
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void Log(ExceptionLoggerContext context)
        {
            exceptionLogger.Error("CustomExceptionLogger.Log", context.Exception);
            base.Log(context);
        }
        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            exceptionLogger.Error("CustomExceptionLogger.LogAsync", context.Exception);
            return base.LogAsync(context, cancellationToken);
        }
        public override bool ShouldLog(ExceptionLoggerContext context)
        {
            exceptionLogger.Error("CustomExceptionLogger.ShouldLog", context.Exception);
            return base.ShouldLog(context);
        }
    }
}