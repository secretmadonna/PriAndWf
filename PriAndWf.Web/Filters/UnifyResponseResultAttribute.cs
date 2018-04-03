using PriAndWf.Web.Models;
using System.Web.Mvc;

namespace PriAndWf.Web.Filters
{
    public class UnifyResponseResultAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            //ResponseResult result = new ResponseResult();

            //// 取得由 API 返回的状态代码
            //result.Code = filterContext..Response.StatusCode;
            //// 取得由 API 返回的资料
            //result.Data = filterContext.ActionContext.Response.Content.ReadAsAsync<object>().Result;
            //// 重新封装回传格式
            //filterContext.Response = filterContext.HttpContext.Response.StatusCode.CreateResponse(result.Status, result);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        { }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        { }
    }
}