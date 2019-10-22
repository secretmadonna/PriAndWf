using log4net;
using PriAndWf.Infrastructure.Extension;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            throw new NotImplementedException();
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            throw new NotImplementedException();
        }
    }
}