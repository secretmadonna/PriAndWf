using System;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace PriAndWf.AdminWeb.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthenticationFilterAttribute : FilterAttribute, IAuthenticationFilter, IMvcFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //从路由获取controller和action
            var controllerName = filterContext.RouteData.Values["controller"] == null
                ? ""
                : filterContext.RouteData.Values["controller"].ToString();
            var actionName = filterContext.RouteData.Values["action"] == null
                ? ""
                : filterContext.RouteData.Values["action"].ToString();

            if (false == string.IsNullOrEmpty(controllerName))
            {
                actionName = string.IsNullOrEmpty(actionName) ? "Index" : actionName;
            }
            else
            {
                //不能从默认的路由"{controller}/{action}/{id}"获取
                var applicationPath = filterContext.HttpContext.Request.ApplicationPath;
                var absolutePath = filterContext.HttpContext.Request.Url.AbsolutePath;

                //根据物理目录和绝对路径截取controller和action
                var controllerPath = applicationPath == @"/"
                    ? absolutePath.Substring(1)
                    : (absolutePath.Length <= applicationPath.Length
                        ? string.Empty
                        : absolutePath.Substring(applicationPath.Length + 1));

                var pathSplit = controllerPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (pathSplit.Length >= 2)
                {
                    controllerName = pathSplit[0];
                    actionName = pathSplit[1];
                }
                else if (pathSplit.Length == 1)
                {
                    controllerName = pathSplit[0];
                    actionName = "Index";
                }
                else
                {
                    controllerName = "Home";
                    actionName = "Index";
                }
            }
            var t=controllerName + @"/" + actionName;
            throw new NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new NotImplementedException();
        }
    }
}