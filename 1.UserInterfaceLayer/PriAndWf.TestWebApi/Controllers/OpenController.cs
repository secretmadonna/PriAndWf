using PriAndWf.TestWebApi.Models.ApiInModels;
using System;
using System.Net.Http;
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

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(new { A = (int)1, B = (decimal)1.1, C = true, D = 'C', E = "S", F = DateTime.Now, G = MyEnum.Enum3 });
        }
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            return Ok(new { Id = id, A = (int)1, B = (decimal)1.1, C = true, D = 'C', E = "S", F = DateTime.Now, G = MyEnum.Enum3 });
        }
        [HttpPost]
        public HttpResponseMessage PostData(MyModel model)
        {
            return Request.CreateResponse(model);
        }
        [HttpPut]
        public HttpResponseMessage PutData(MyModel model)
        {
            return Request.CreateResponse(model);
        }

        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
        {
            return Ok();
        }



        public IHttpActionResult GetById(string id)
        {
            return Ok(new { ID = id, A = (int)1, B = (decimal)1.1, C = true, D = 'C', E = "S", F = DateTime.Now, G = MyEnum.Enum3 });
        }
    }

    public enum MyEnum : int
    {
        Enum1 = 0,
        Enum2,
        Enum3,
        Enum4
    }

    public class MyModel
    {
        public int Id { get; set; }
        public string LoginName { get; set; }
        public string PassWord { get; set; }
    }
}
