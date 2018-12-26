using log4net;
using log4net.Config;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;

//[assembly: XmlConfigurator(ConfigFile = "log4net", ConfigFileExtension = "config", Watch = true)]
[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace PriAndWf.TestWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private ILog staticLogger = LogManager.GetLogger("StaticLogger");
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void Init()
        {
            var info = string.Format("{0}()", MethodBase.GetCurrentMethod().Name);
            staticLogger.Info(info);
            this.PostAuthenticateRequest += (sender, e) =>//此事件之后才可访问Session
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            };
            base.Init();
        }
        /// <summary>
        /// Application_OnStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(Object sender, EventArgs e)
        {
            //throw new Exception("手动抛出异常，用于测试。");
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
            //throw new Exception("手动抛出异常！");
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
        /// <summary>
        /// Application_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnEnd(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        /// <summary>
        /// Session_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnEnd(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            //var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            var info = string.Format("{0}({1}[{3}],{2})  {4}", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName, Session.SessionID);
            staticLogger.Info(info);
        }

        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnError(Object sender, EventArgs e)
        {
            exceptionLogger.Error("WebApiApplication.Application_OnError", ((WebApiApplication)sender).Context.Error);
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnStart(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            //var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            var info = string.Format("{0}({1}[{3}],{2})  {4}", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName, Session.SessionID);
            staticLogger.Info(info);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})  {4}", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName, Request.RawUrl);
            staticLogger.Info(info);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostAuthorizeRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostResolveRequestCache(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostReleaseRequestState(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostUpdateRequestCache(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_LogRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PostLogRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            var senderType = sender.GetType();
            var info = string.Format("{0}({1}[{3}],{2})", MethodBase.GetCurrentMethod().Name, senderType.FullName, e.GetType().FullName, senderType.BaseType.FullName);
            staticLogger.Info(info);
        }
    }
}
