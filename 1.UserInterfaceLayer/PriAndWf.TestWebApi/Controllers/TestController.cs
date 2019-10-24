using PriAndWf.Infrastructure.Extension;
using PriAndWf.TestWebApi.Core;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace PriAndWf.TestWebApi.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            //WebClient;
            //WebUtility;
            //WebRequest;
            //HttpWebRequest;
            //HttpContextBase;
            //HttpContext;
            //HttpRequestBase;
            //HttpRequest;
            var ctx = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var str = "`-=  []\\;',./ ~!@#$%^&*()_+{}|:\"<>?";
            // UrlEncode : "%60-%3D+++%5B%5D%5C%3B+%27%2C.%2F+%7E!%40%23%24%25%5E%26*()_%2B%7B%7D%7C%3A%22%3C%3E%3F"
            // HtmlEncode : "`-=   []\\; &#39;,./ ~!@#$%^&amp;*()_+{}|:&quot;&lt;&gt;?"
            var str1 = HttpUtility.UrlEncode(str);
            var str2 = HttpUtility.HtmlEncode(str);
            return Ok(new
            {
                User.Identity.AuthenticationType,
                User.Identity.IsAuthenticated,
                User.Identity.Name,
                str1,
                str2
            });









            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var random = context.Application["DfTestRandom"] as Random;
            var i = random.Next(1, 5);//1.2.3.4

            var r = new CommonResponse<int>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = i
            };
            if (i == 1)//异常
            {
                throw new Exception("测试异常！！！");
            }
            else if (i == 2)//未授权
            {
                r.ret = (int)RetCode.Unauthorized;
                r.msg = RetCode.Unauthorized.Description();
                r.data = 0;
                return Unauthorized();
            }
            else if (i == 3)
            {
                Thread.Sleep(6000);
                return Ok(r);
            }
            else
            {
                return Ok(r);
            }
        }
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var rd = context.Application["DfTestRandom"] as Random;
            var i = rd.Next(1, 5);//1.2.3.4

            var r = new CommonResponse<string>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = i.ToString()
            };
            var authorization = Request.Headers.Contains("Authorization");
            if (authorization)
            {
                //Thread.Sleep(10000);
                return Request.CreateResponse(HttpStatusCode.OK, r);
            }
            else
            {
                r.ret = (int)RetCode.Unauthorized;
                r.msg = RetCode.Unauthorized.Description();
                r.data = null;
                return Request.CreateResponse(HttpStatusCode.Unauthorized, r);
            }
            //if (i == 1)//异常
            //{
            //    throw new Exception("测试异常！！！");
            //}
            //else if (i == 2)//未授权
            //{
            //    r.ret = (int)RetCode.Unauthorized;
            //    r.msg = RetCode.Unauthorized.Description();
            //    r.data = null;
            //    return Request.CreateResponse(HttpStatusCode.Unauthorized, r);
            //}
            //else if (i == 3)
            //{
            //    Thread.Sleep(10000);
            //    return Request.CreateResponse(HttpStatusCode.OK, r);
            //}
            //else
            //{
            //    return Request.CreateResponse(HttpStatusCode.OK, r);
            //}
        }
    }
}
