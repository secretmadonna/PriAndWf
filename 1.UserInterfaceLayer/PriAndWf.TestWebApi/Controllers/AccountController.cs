using System.Web.Http;

namespace PriAndWf.TestWebApi.Controllers
{
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
            return Ok();
        }
    }
}
