using PriAndWf.TestWebApi.Core;
using System.Configuration;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ExceptionHandling;

namespace PriAndWf.TestWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            //config.Services.Add(typeof(IExceptionLogger), new CustomExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());
            //System.Web.Http.ExceptionHandling.ExceptionLogger
            //System.Web.Http.ExceptionHandling.ExceptionHandler System.Web.Http.WebHost.WebHostExceptionHandler System.Web.Http.ExceptionHandling.DefaultExceptionHandler
            //var services = config.Services.GetServices(typeof(IExceptionHandler));
            //config.Services.Remove(typeof(IExceptionHandler), services);


            //config.Filters.Add(new CustomAuthorizationFilterAttribute());
            //config.Filters.Add(new CustomActionFilterAttribute());
            //config.Filters.Add(new CustomExceptionFilterAttribute());

            config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

            #region cors
            // W3C的CORS规范：浏览器应该采用一种被称为“预检（preflight）”的机制来完成非简单跨域资源请求
            // 
            // 简单请求（Simple Request） : 请求采用“简单方法”，并且其“自定义请求报头”为空或者所有“自定义请求报头”均为“简单请求报头”
            //     简单方法（Simple Method） : GET、HEAD、POST
            //     简单请求报头（Simple Request Header） : Accept、Accept-Language、Content-Language、Content-Type（application/x-www-form-urlencoded、multipart/form-data、text/plain）
            //     自定义请求报头（Author Request Header / Custom Request Header） : XMLHttpRequest.setRequestHeader
            // 
            // 简单响应报头（Simple Response Header） : Cache-Control、Content-Language、Content-Type、Expires、Last-Modified、Pragma
            // 说明：只有在“Access-Control-Expose-Headers”报头中指定的报头和“简单响应报头”会包含在 XMLHttpRequest.getResponseHeader 方法返回的列表中
            var allowOrigins = ConfigurationManager.AppSettings["cors:allowOrigins"];
            var allowHeaders = ConfigurationManager.AppSettings["cors:allowHeaders"];
            var allowMethods = ConfigurationManager.AppSettings["cors:allowMethods"];
            var exposedHeaders = ConfigurationManager.AppSettings["cors:exposedHeaders"];
            var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods, exposedHeaders)
            {
                SupportsCredentials = true
            };
            config.EnableCors(globalCors);
            #endregion

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
