using log4net;
using PriAndWf.Application;
using PriAndWf.Infrastructure.Extension;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace PriAndWf.TestWebApi.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class BasicAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
    {
        private const string authenticationScheme = "Basic";
        private const string authenticationRealm = "realm";

        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private UserApplicationService userApplicationService;

        public BasicAuthenticationFilterAttribute()
        {
            userApplicationService = new UserApplicationService();
        }
        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo() + Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);

            return Task.Factory.StartNew(() =>
            {
                var request = context.Request;
                var authorization = request.Headers.Authorization;
                if (authorization != null)
                {
                    if (authorization.Scheme.Equals(authenticationScheme))
                    {
                        //WWW-Authenticate:Basic 【Base64(userid:password)】"（备注：【】中是伪代码。userid 不能包含冒号（:））
                        var authorizationParameter = authorization.Parameter;
                        var useridAndPasswordStr = Encoding.Default.GetString(Convert.FromBase64String(authorizationParameter));
                        var useridAndPasswordArray = useridAndPasswordStr.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (useridAndPasswordArray.Length == 2)
                        {
                            //登录名和密码：区分大小写？？？
                            var userid = useridAndPasswordArray[0];
                            var password = useridAndPasswordArray[1];
                            var user = userApplicationService.GetByLoginName(userid);
                            if (user != null && user.Password.Equals(password))
                            {
                                var principal = new GenericPrincipal(new GenericIdentity(user.UserName, authenticationScheme), null);
                                context.Principal = principal;
                                Thread.CurrentPrincipal = principal;
                            }
                        }
                    }
                }
            });
        }
        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo() + Environment.NewLine);

            return Task.Factory.StartNew(() =>
            {
                var principal = context.ActionContext.ControllerContext.RequestContext.Principal;
                if (principal == null || !principal.Identity.IsAuthenticated)
                {
                    var challenges = new List<AuthenticationHeaderValue>();
                    challenges.Add(new AuthenticationHeaderValue(authenticationScheme, $"{authenticationRealm}={context.Request.RequestUri.DnsSafeHost}"));
                    context.Result = new UnauthorizedResult(challenges, context.Request);
                }
            });
        }
        public override bool AllowMultiple
        {
            get { return true; }
        }
    }
}
