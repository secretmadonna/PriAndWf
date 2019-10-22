using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.ExceptionHandling;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomExceptionLogger : ExceptionLogger
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Log(ExceptionLoggerContext context)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Error(method.DescInfo(), context.Exception);
            var stackTrace = new StackTrace(true);
            logger.Error(stackTrace.DescInfo(), context.Exception);

            base.Log(context);
        }
        public override Task LogAsync(ExceptionLoggerContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Error(method.DescInfo()); //logger.Error(method.DescInfo(), context.Exception);

            return base.LogAsync(context, cancellationToken);
        }
        public override bool ShouldLog(ExceptionLoggerContext context)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Error(method.DescInfo()); //logger.Error(method.DescInfo(), context.Exception);

            return base.ShouldLog(context);
        }
    }
}