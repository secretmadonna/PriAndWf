using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
    {
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}