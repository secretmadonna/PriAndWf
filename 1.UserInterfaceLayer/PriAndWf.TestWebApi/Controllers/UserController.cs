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
    public class UserController : ApiController
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
        public IHttpActionResult GetAll()
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
        public IHttpActionResult GetById(int id)
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
        public HttpResponseMessage PostData(UserModel model)
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
        public HttpResponseMessage PutData(UserModel model)
        {
            var r = new CommonResponse<UserModel>()
            {
                ret = (int)RetCode.OK,
                msg = RetCode.OK.Description(),
                data = model
            };
            return Request.CreateResponse(r);
        }

        [HttpDelete]
        public IHttpActionResult DeleteById(int id)
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
