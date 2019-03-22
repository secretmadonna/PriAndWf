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
                Thread.Sleep(10000);
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
            if (i == 1)//异常
            {
                throw new Exception("测试异常！！！");
            }
            else if (i == 2)//未授权
            {
                r.ret = (int)RetCode.Unauthorized;
                r.msg = RetCode.Unauthorized.Description();
                r.data = null;
                return Request.CreateResponse(HttpStatusCode.Unauthorized, r);
            }
            else if (i == 3)
            {
                Thread.Sleep(10000);
                return Request.CreateResponse(HttpStatusCode.OK, r);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, r);
            }
        }
    }
}
