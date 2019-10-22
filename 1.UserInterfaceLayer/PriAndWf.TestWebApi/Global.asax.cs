using log4net;
using log4net.Config;
using System;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.SessionState;
using System.Diagnostics;
using PriAndWf.Infrastructure.Extension;

//[assembly: XmlConfigurator(ConfigFile = "log4net", ConfigFileExtension = "config", Watch = true)]
[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace PriAndWf.TestWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void Init()
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());

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
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());

            Application["DfTestRandom"] = new Random();
            //throw new Exception("手动抛出异常，用于测试。");
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
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        /// <summary>
        /// Session_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnEnd(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(string.Format("{0} {1}", Session.SessionID, method.DescInfo()));

            var stackTrace = new StackTrace(true);
            logger.Info(string.Format("{0} {1}", Session.SessionID, stackTrace.DescInfo()));
        }

        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnError(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Error(method.DescInfo(), ((WebApiApplication)sender).Context.Error);

            var stackTrace = new StackTrace(true);
            logger.Error(stackTrace.DescInfo(), ((WebApiApplication)sender).Context.Error);
        }
        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnStart(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(string.Format("{0} {1}", Session.SessionID, method.DescInfo()));

            var stackTrace = new StackTrace(true);
            logger.Info(string.Format("{0} {1}", Session.SessionID, stackTrace.DescInfo()));
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(string.Format("{0} {1}", Request.RawUrl, method.DescInfo()));

            var stackTrace = new StackTrace(true);
            logger.Info(string.Format("{0} {1}", Request.RawUrl, stackTrace.DescInfo()));
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostAuthorizeRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostResolveRequestCache(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostReleaseRequestState(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostUpdateRequestCache(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_LogRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PostLogRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(string.Format("{0} {1}", method.DescInfo(), Request.RawUrl));

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            var stackTrace = new StackTrace(true);
            logger.Info(stackTrace.DescInfo());
        }
    }
}
