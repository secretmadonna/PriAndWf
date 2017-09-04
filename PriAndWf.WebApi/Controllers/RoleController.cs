using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PriAndWf.WebApi.Controllers
{
    public class RoleController : BaseApiController
    {
        public class ApiResult<T>
        {
            public int Code { get; set; }
            public string Description { get; set; }
            public T Data { get; set; }
        }
        public class Role
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        public IHttpActionResult GetTestData1()
        {
            var result = new ApiResult<List<Role>>()
            {
                Code = 0,
                Description = "success",
                Data = new List<Role> {
                    new Role() { Id = 1,Name = "SupperAdmin"},
                    new Role() { Id = 2,Name = "Admin" }
                }
            };
            return Json<ApiResult<List<Role>>>(result);
        }
        public ApiResult<List<Role>> GetTestData2()
        {
            var result = new ApiResult<List<Role>>()
            {
                Code = -1,
                Description = "fail"
            };
            return result;
        }
    }
}