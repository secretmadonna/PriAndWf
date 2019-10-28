using log4net;
using PriAndWf.Application;
using PriAndWf.Infrastructure.Extension;
using PriAndWf.Infrastructure.Helper;
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
        private const string authenticationQop = "qop"; //2个可选值：auth（默认）和auth-int（增加了报文完整性检测）
        private const string authenticationNonce = "nonce";
        private const string authenticationUsername = "username";
        private const string authenticationUri = "uri";
        private const string authenticationNc = "nc";
        private const string authenticationConnce = "connce";
        private const string authenticationResponse = "response";
        private const string authenticationNextnonce = "nextnonce";
        private const string authenticationRspauth = "rspauth";
        private const string authenticationStale = "stale";

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
                        var authorizationParameterArray = authorization.Parameter.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        var dic = new Dictionary<string, string>();
                        if (authorizationParameterArray.Length == 8)
                        {
                            for (int i = 0; i < authorizationParameterArray.Length; i++)
                            {
                                var kv=authorizationParameterArray[i].Trim().Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                                if (kv.Length == 2)
                                {
                                    var k = kv[0].Trim().Trim(new char[] { '"'});
                                    var v = kv[1].Trim().Trim(new char[] { '"' });
                                    if (k == authenticationRealm)
                                    {
                                        dic.Add(authenticationRealm, v);
                                    }
                                    else if (k == authenticationQop)
                                    {
                                        dic.Add(authenticationQop, v);
                                    }
                                    else if (k == authenticationNonce)
                                    {
                                        dic.Add(authenticationNonce, v);
                                    }
                                    else if (k == authenticationUsername)
                                    {
                                        dic.Add(authenticationUsername, v);
                                    }
                                    else if (k == authenticationUri)
                                    {
                                        dic.Add(authenticationUri, v);
                                    }
                                    else if (k == authenticationNc)
                                    {
                                        dic.Add(authenticationNc, v);
                                    }
                                    else if (k == authenticationConnce)
                                    {
                                        dic.Add(authenticationConnce, v);
                                    }
                                    else if (k == authenticationResponse)
                                    {
                                        dic.Add(authenticationResponse, v);
                                    }
                                }
                            }
                            if (dic[authenticationRealm] != null && dic[authenticationQop] != null && dic[authenticationNonce] != null && dic[authenticationUsername] != null
                            && dic[authenticationUri] != null && dic[authenticationNc] != null && dic[authenticationConnce] != null && dic[authenticationResponse] != null)
                            {
                                var user = userApplicationService.GetByLoginName(dic[authenticationUsername]);
                                if (user != null)
                                {
                                    string a1, a2;
                                    if (dic[authenticationQop].Equals("auth"))
                                    {
                                        a1 = $"{dic[authenticationUsername]}:{dic[authenticationRealm]}:{user.Password}";
                                        a2 = $"{request.Method.Method}:{dic[authenticationUri]}";
                                    }
                                    else if (dic[authenticationQop].Equals("auth-int"))
                                    {
                                        a1 = $"{RsaHelper.GetStringDigest($"{dic[authenticationUsername]}:{dic[authenticationRealm]}:{user.Password}")}:{dic[authenticationNonce]}:{dic[authenticationConnce]}";
                                        a2 = $"{request.Method.Method}:{dic[authenticationUri]}:{RsaHelper.GetStringDigest(request.Content.ReadAsStreamAsync().Result)}";
                                    }
                                    
                                    var response = RsaHelper.GetStringDigest()}:{}");
                                    if (  user.Password.Equals(password))
                                    var principal = new GenericPrincipal(new GenericIdentity(user.UserName, authenticationScheme), null);
                                    context.Principal = principal;
                                    Thread.CurrentPrincipal = principal;
                                }
                            }
                        }
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
                    authorizationParameterArray.Add($"{authenticationQop}=auth");
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
