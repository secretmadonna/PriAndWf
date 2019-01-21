using PriAndWf.Infrastructure.Extension;
using PriAndWf.TestWebApi.Core;
using PriAndWf.TestWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace PriAndWf.TestWebApi.Controllers
{
    /// <summary>
    /// （R）GET : 安全、幂等。用于获取资源
    /// （C）POST : 非安全、非幂等。用于创建子资源
    /// （U）PUT : 非安全、幂等。用于创建、更新资源
    /// （D）DELETE : 非安全、幂等。用于删除资源
    /// OPTIONS : 安全、幂等。用于接口验证
    /// PATCH : 非安全、幂等。用于创建、更新资源（与 PUT 的区别 : PATCH 代表部分更新，只更新字段属性不为 NULL 的）
    /// HEAD : 安全、幂等。RESTFUL 框架中较少使用
    /// TEACE : 安全、幂等。RESTFUL 框架中较少使用
    /// </summary>
    public class UsersController : ApiController
    {
        //public UserController()
        //{
        //    throw new Exception("手动抛出异常，用于测试。");
        //}

        private List<UserModel> users = new List<UserModel>() {
            new UserModel() { UserID = 1, UserName = "test1", PassWord = "123456", NickName = "test1", Gender = UserGender.Male, Birthday = new DateTime(2018, 1, 1), Balance = 0.123M, CreateDateTime = DateTime.Now, Active = true },
            new UserModel() { UserID = 2, UserName = "test2", PassWord = "123456", NickName = "test2", Gender = UserGender.Female, Birthday = new DateTime(2018, 1, 1), Balance = 123M, CreateDateTime = DateTime.Now, Active = false },
            new UserModel() { UserID = 3, UserName = "test3", PassWord = "123456", NickName = "test3", Gender = UserGender.Female, Birthday = new DateTime(2018, 1, 1), Balance = 123.123M, CreateDateTime = DateTime.Now, Active = true },
        };
        [HttpGet]
        public IHttpActionResult Get()
        {
            var r = new CommonResponse<List<UserModel>>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = users
            };
            return Ok(r);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            //throw new Exception("手动抛出异常，用于测试。");
            var r = new CommonResponse<UserModel>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = users.FirstOrDefault(m => m.UserID == id)
            };
            return Ok(r);
        }
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserModel model)
        {
            var r = new CommonResponse<UserModel>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = model
            };
            return Request.CreateResponse(r);
        }
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody]UserModel model)
        {
            var r = new CommonResponse<UserModel>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = model
            };
            return Request.CreateResponse(r);
        }
        /// <summary>
        /// 更新不为 NULL 的数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch]
        public IHttpActionResult Patch(int id, [FromBody]UserModel model)
        {
            var r = new CommonResponse()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description()
            };
            return Ok(r);
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var r = new CommonResponse()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description()
            };
            return Ok(r);
        }

    }
}
