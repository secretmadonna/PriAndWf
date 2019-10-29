using log4net;
using PriAndWf.Application;
using PriAndWf.Infrastructure.Extension;
using PriAndWf.Infrastructure.Helper;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    public static class QopValues
    {
        public const string Auth = "auth";
        public const string AuthInt = "auth-int";
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class DigestAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IFilter
    {
        private const string authenticationScheme = "Digest";
        private const string authenticationRealm = "realm"; 
        private const string authenticationQop = "qop"; //auth（默认）、auth-int（增加了报文完整性检测）、token
        private const string authenticationNonce = "nonce";
        private const string authenticationUsername = "username";
        private const string authenticationUri = "uri";
        private const string authenticationNc = "nc";
        private const string authenticationConnce = "connce";
        private const string authenticationResponse = "response";
        private const string authenticationNextnonce = "nextnonce";
        private const string authenticationRspauth = "rspauth";
        private const string authenticationStale = "stale";


        private const string authenticationDomain = "domain";
        private const string authenticationOpaque = "opaque";
        private const string authenticationAlgorithm = "algorithm";

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
                    if (authorization.Scheme.Equals(authenticationScheme))
                    {
                        ////WWW-Authenticate:Digest username="【loginName】", realm="【realm】", nonce="【nonce】", uri="【uri】", cnonce="【cnonce】", nc="【nc】", response="【response】", qop="【qop】"
                        logger.Info(authorization.Parameter + Environment.NewLine);

                        var eTag = context.Request.Headers.IfNoneMatch.ToString();
                        var privateKey = ConfigurationManager.AppSettings["DigestPrivateKey"];
                        for (int i = 0; i < 20; i++)
                        {
                            var timeStamp = DateTimeHelper.ToTimestamp();
                            var nonce = GenerateNonce(timeStamp, eTag, privateKey);
                            logger.Info($"{timeStamp} {nonce}" + Environment.NewLine);
                            new RedisHelper().StringIncrement($"nonce:{nonce}");
                        }
                        return;



                        var authorizationParameterArray = authorization.Parameter.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        var dic = new Dictionary<string, string>();
                        for (int i = 0; i < authorizationParameterArray.Length; i++)
                        {
                            var kv = authorizationParameterArray[i].Trim().Split(new string[] { "=" }, 2, StringSplitOptions.RemoveEmptyEntries);
                            if (kv.Length == 2)
                            {
                                var k = kv[0].Trim().Trim(new char[] {  '"' });
                                var v = kv[1].Trim().Trim(new char[] {  '"' });
        //                        private const string authenticationScheme = "Digest";
        //private const string authenticationRealm = "realm";
        //private const string authenticationQop = "qop"; //auth（默认）、auth-int（增加了报文完整性检测）、token
        //private const string authenticationNonce = "nonce";
        //private const string authenticationUsername = "username";
        //private const string authenticationUri = "uri";
        //private const string authenticationNc = "nc";
        //private const string authenticationConnce = "connce";
        //private const string authenticationResponse = "response";
        //private const string authenticationNextnonce = "nextnonce";
        //private const string authenticationRspauth = "rspauth";
        //private const string authenticationStale = "stale";


        //private const string authenticationDomain = "domain";
        //private const string authenticationOpaque = "opaque";
        //private const string authenticationAlgorithm = "algorithm";
                                switch (k)
                                {
                                    case authenticationRealm:
                                        dic.Add(authenticationRealm, v);
                                        break;
                                    case authenticationQop:
                                        dic.Add(authenticationQop, v);
                                        break;
                                    case authenticationNonce:
                                        dic.Add(authenticationNonce, v);
                                        break;
                                    case authenticationUsername:
                                        dic.Add(authenticationUsername, v);
                                        break;
                                    case authenticationUri:
                                        dic.Add(authenticationUri, v);
                                        break;
                                    case authenticationNc:
                                        dic.Add(authenticationNc, v);
                                        break;
                                    case authenticationConnce:
                                        dic.Add(authenticationConnce, v);
                                        break;
                                    case authenticationResponse:
                                        dic.Add(authenticationResponse, v);
                                        break;
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

                                //var response = RsaHelper.GetStringDigest()}:{}");
                                //if (  user.Password.Equals(password))
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
                    var authorizationParameterArray = new List<string>();
                    authorizationParameterArray.Add($"{authenticationRealm}={context.Request.RequestUri.DnsSafeHost}");
                    var timeStamp = DateTimeHelper.ToTimestamp();
                    var eTag = context.Request.Headers.IfNoneMatch.ToString();
                    var privateKey = ConfigurationManager.AppSettings["DigestPrivateKey"];
                    authorizationParameterArray.Add($"{authenticationNonce}={GenerateNonce(timeStamp, eTag, privateKey)}");
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

        /// <summary>
        /// 生成 nonce
        ///   time-stamp H(time-stamp ":" ETag ":" private-key)
        /// </summary>
        /// <param name="timeStamp">由服务器产生的时间值或其他非重复值</param>
        /// <param name="eTag">ETag报头的值</param>
        /// <param name="privateKey">只有服务器才知道的值</param>
        /// <returns></returns>
        private string GenerateNonce(long timeStamp, string eTag, string privateKey)
        {
            var md5 = RsaHelper.GetStringDigest($"{timeStamp}:{eTag}:{privateKey}");
            var base64 = Base64Helper.Encode($"{timeStamp} {md5}");
            return base64;
        }
        //private bool IsNonceValid(string nonce, string eTag, string privateKey)
        //{
        //    var tempStr = Base64Helper.Decode(nonce);
        //    var timeStamp = long.Parse(tempStr.Substring(0, tempStr.IndexOf(' ')));
        //    if (nonce != GenerateNonce(eTag, privateKey, timeStamp))
        //    {
        //        return false; // nonce 被篡改
        //    }
        //    if ((DateTime.Now - DateTimeHelper.startDateTime.AddMilliseconds(timeStamp)).TotalSeconds > 10)
        //    {
        //        return false; // 已过期
        //    }
        //    return true;
        //}
    }
}
