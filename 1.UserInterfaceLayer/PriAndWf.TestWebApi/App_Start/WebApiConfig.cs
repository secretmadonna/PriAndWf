using PriAndWf.TestWebApi.Core;
using System.Configuration;
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
            config.Services.Add(typeof(IExceptionLogger), new CustomExceptionLogger());
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());

            config.Filters.Add(new CustomAuthorizationFilterAttribute());
            config.Filters.Add(new CustomActionFilterAttribute());
            config.Filters.Add(new CustomExceptionFilterAttribute());

            #region cors
            //var allowOrigins = ConfigurationManager.AppSettings["cors:allowOrigins"];
            //var allowHeaders = ConfigurationManager.AppSettings["cors:allowHeaders"];
            //var allowMethods = ConfigurationManager.AppSettings["cors:allowMethods"];
            //var globalCors = new EnableCorsAttribute(allowOrigins, allowHeaders, allowMethods)
            //{
            //    SupportsCredentials = true
            //};
            //config.EnableCors(globalCors);
            #endregion
            
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            //config.Formatters.Insert(0, new JsonpMediaTypeFormatter());

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
