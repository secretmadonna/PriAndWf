using PriAndWf.JustWebApi.Models.ApiInModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace PriAndWf.JustWebApi.Controllers
{
    public class OpenController : ApiController
    {
        #region 签到
        [HttpPost]
        public IHttpActionResult SignIn([FromBody]SignInModel model)
        {
            if (model == null)
            {
                var parameterName = nameof(model);
                ModelState.AddModelError(parameterName, string.Format("{0} 不能为空", parameterName));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(model);
        }
        #endregion
    }
}
