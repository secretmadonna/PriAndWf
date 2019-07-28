using PriAndWf.Infrastructure.Extension;
using PriAndWf.TestWebApi.Core;
using PriAndWf.TestWebApi.Models;
using System;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace PriAndWf.TestWebApi.Controllers
{
    [RoutePrefix("api")]
    public class AccountController : ApiController
    {
        [HttpGet, HttpPost, Route("account/gettoken")]
        public IHttpActionResult Login(string username, string password)
        {
            return Ok();
        }

        [HttpGet, HttpPost, Route("account/refreshtoken")]
        public IHttpActionResult RefreshToken(string refreshToken)
        {
            var context = (HttpContextBase)Request.Properties["MS_HttpContext"];
            var rd = context.Application["DfTestRandom"] as Random;
            var i = rd.Next(1, 4);//1.2.3

            var r = new CommonResponse<Token>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = null
            };
            if (i == 1)//异常
            {
                throw new Exception("测试异常！！！");
            }
            else if (i == 2)
            {
                Thread.Sleep(10000);
            }
            if (refreshToken == "1")
            {
                r.ret = -1;
                r.msg = "无效的 refreshToken";
                return Ok(r);
            }
            r.data = new Token()
            {
                TokenType = "bearer",
                Scope = "read",
                AccessToken = Guid.NewGuid().ToString(),
                ExpiresIn = 10,
                RefreshToken = Guid.NewGuid().ToString()
            };
            return Ok(r);
        }
    }
}
