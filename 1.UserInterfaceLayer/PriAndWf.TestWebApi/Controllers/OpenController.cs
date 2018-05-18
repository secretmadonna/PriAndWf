using PriAndWf.TestWebApi.Models.ApiInModels;
using System.Web.Http;

namespace PriAndWf.TestWebApi.Controllers
{
    public class OpenController : ApiController
    {
        #region 签到
        [HttpPost]
        public IHttpActionResult SignIn(SignInModel model, string abc = "abc")
        {
            //if (model == null)
            //{
            //    var parameterName = nameof(model);
            //    ModelState.AddModelError(parameterName, string.Format("{0} 不能为空", parameterName));
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(new { model, abc });
        }
        #endregion
    }
}
