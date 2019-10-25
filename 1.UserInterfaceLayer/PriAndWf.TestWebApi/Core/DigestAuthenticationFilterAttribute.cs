//using log4net;
//using PriAndWf.Application;
//using PriAndWf.Infrastructure.Extension;
//using PriAndWf.Infrastructure.Helper;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Net;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Reflection;
//using System.Security.Principal;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web.Http.Filters;
//using System.Web.Http.Results;

//namespace PriAndWf.TestWebApi.Core
//{
//    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
//    public class DigestAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
//    {
//        private const string AuthenticationScheme = "Basic";
//        private const string AuthenticationRealm = "realm";

//        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
//        private UserApplicationService userApplicationService;

//        public DigestAuthenticationFilterAttribute()
//        {
//            userApplicationService = new UserApplicationService();
//        }
//        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
//        {
//            var method = (MethodInfo)MethodBase.GetCurrentMethod();
//            logger.Info(method.DescInfo() + Environment.NewLine);
//            //var stackTrace = new StackTrace(true);
//            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);

//            return Task.Factory.StartNew(() =>
//            {
//                var request = context.Request;
//                var authorization = request.Headers.Authorization;
//                if (authorization != null)
//                {
//                    if (authorization.Scheme == "Digest")
//                    {
//                        //"Basic Base64(loginName:password)"
//                        var loginNameAndPasswordStr = Encoding.Default.GetString(Convert.FromBase64String(authorization.Parameter));
//                        var loginNameAndPasswordArray = loginNameAndPasswordStr.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
//                        if (loginNameAndPasswordArray.Length == 2)
//                        {
//                            //登录名和密码：区分大小写？？？
//                            var loginName = loginNameAndPasswordArray[0];
//                            var password = loginNameAndPasswordArray[1];
//                            var user = userApplicationService.GetByLoginName(loginName);
//                            if (user != null && user.Password.Equals(password))
//                            {
//                                var principal = new GenericPrincipal(new GenericIdentity(user.UserName, "Basic"), null);
//                                context.Principal = principal;
//                                Thread.CurrentPrincipal = principal;
//                            }
//                        }
//                        else
//                        {
//                            //context.ErrorResult = Unauthorized(context.Request);
//                        }
//                    }
//                }
//            });
//        }
//        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
//        {
//            var method = (MethodInfo)MethodBase.GetCurrentMethod();
//            logger.Info(method.DescInfo() + Environment.NewLine);

//            return Task.Factory.StartNew(() =>
//            {
//                var principal = context.ActionContext.ControllerContext.RequestContext.Principal;
//                if (principal == null || !principal.Identity.IsAuthenticated)
//                {
//                    var challenges = new List<AuthenticationHeaderValue>();
//                    challenges.Add(new AuthenticationHeaderValue("Digest", string.Format("realm={0}", context.Request.RequestUri.DnsSafeHost)));
//                    context.Result = new UnauthorizedResult(challenges, context.Request);
//                }
//            });
//        }
//        public override bool AllowMultiple
//        {
//            get { return true; }
//        }
//    }
//}
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
    public class DigestAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
    {
        private const string authenticationScheme = "Digest";
        private const string authenticationRealm = "realm";
        private const string authenticationQop = "qop";
        private const string authenticationNonce = "nonce";

        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private UserApplicationService userApplicationService;

        public DigestAuthenticationFilterAttribute()
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
                    if (authorization.Scheme == authenticationScheme)
                    {
                        //WWW-Authenticate:Digest username="【loginName】", realm="【realm】", nonce="【nonce】", uri="【uri】", cnonce="【cnonce】", nc="【nc】", response="【response】", qop="【qop】"
                        logger.Info(authorization.Parameter + Environment.NewLine);
                        var authorizationParameterArray = authorization.Parameter.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                        ////"Digest 【Base64(loginName:password)】"（不包含【】）
                        //var loginNameAndPasswordStr = Encoding.Default.GetString(Convert.FromBase64String(authorization.Parameter));
                        //var loginNameAndPasswordArray = loginNameAndPasswordStr.Split(new char[] { ':' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        //if (loginNameAndPasswordArray.Length == 2)
                        //{
                        //    //登录名和密码：区分大小写？？？
                        //    var loginName = loginNameAndPasswordArray[0];
                        //    var password = loginNameAndPasswordArray[1];
                        //    var user = userApplicationService.GetByLoginName(loginName);
                        //    if (user != null && user.Password.Equals(password))
                        //    {
                        //        var principal = new GenericPrincipal(new GenericIdentity(user.UserName, authenticationScheme), null);
                        //        context.Principal = principal;
                        //        Thread.CurrentPrincipal = principal;
                        //    }
                        //}
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
                    var authorizationParameterArray = new List<string>();
                    authorizationParameterArray.Add($"{authenticationRealm}={context.Request.RequestUri.DnsSafeHost}");
                    authorizationParameterArray.Add($"{authenticationQop}=auth");//2个可选值：auth（默认）和auth-int（增加了报文完整性检测）
                    authorizationParameterArray.Add($"{authenticationNonce}={DateTime.Now.Ticks}");
                    challenges.Add(new AuthenticationHeaderValue(authenticationScheme, string.Join(", ", authorizationParameterArray)));
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
