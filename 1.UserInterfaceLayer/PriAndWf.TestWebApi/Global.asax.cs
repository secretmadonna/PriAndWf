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

        #region Pipeline
        /// <summary>
        /// Application_OnStart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Start(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);

            Application["DfTestRandom"] = new Random();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// Init
        /// </summary>
        public override void Init()
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);

            this.PostAuthenticateRequest += (sender, e) =>//此事件之后才可访问Session
            {
                HttpContext.Current.SetSessionStateBehavior(SessionStateBehavior.Required);
            };
            base.Init();
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("Application_BeginRequest : {0}", Request.RawUrl + Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Info(string.Format("{0}{1}{2}{3}", Environment.NewLine, stackTrace.DescInfo(), Environment.NewLine, Request.RawUrl + Environment.NewLine));
            //throw new Exception("测试异常！！！");
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostAuthorizeRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostResolveRequestCache(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// Application_PostMapRequestHandler 之后执行
        ///   如何被调用？？？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnStart(Object sender, EventArgs e)
        {
            logger.InfoFormat("Session_OnStart : {0} {1}{2}", Request.RawUrl, Session.SessionID, Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Info(string.Format("{0}{1}{2}{3}", Environment.NewLine, stackTrace.DescInfo(), Environment.NewLine, Session.SessionID + Environment.NewLine));
            //throw new Exception("测试异常！！！");
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }

        // HttpHandler

        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostReleaseRequestState(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        protected void Application_PostUpdateRequestCache(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_LogRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（若前面的方法已经发生过异常，不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PostLogRequest(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（若前面的方法已经发生过异常，不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            logger.InfoFormat("Application_EndRequest : {0}{1}", Request.RawUrl, Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（若前面的方法已经发生过异常，不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（若前面的方法已经发生过异常，不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// 总是会被执行（Application_PreSendRequestHeaders 一旦发生异常，Application_PreSendRequestContent 将不会被执行）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（若前面的方法已经发生过异常，不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }

        /// <summary>
        /// 前面的方法发生了错误，该方法会被执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnError(Object sender, EventArgs e)
        {
            logger.InfoFormat("Application_OnError : {0}{1}", (sender as WebApiApplication)?.Context?.Error?.ToString() ?? string.Empty, Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Error(string.Format("{0}{1}{2}{3}", Environment.NewLine, stackTrace.DescInfo(), Environment.NewLine, (sender as WebApiApplication)?.Context?.Error?.ToString() ?? string.Empty + Environment.NewLine));
            //该方法中发生异常如何处理？？？（不会再由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        #endregion

        /// <summary>
        /// Session_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnEnd(Object sender, EventArgs e)
        {
            logger.InfoFormat("Session_OnEnd : {0}{1}", Session.SessionID, Environment.NewLine);
            //var stackTrace = new StackTrace(true);
            //logger.Info(string.Format("{0}{1}{2}{3}", Environment.NewLine, stackTrace.DescInfo(), Environment.NewLine, Session.SessionID + Environment.NewLine));
            //该方法中发生异常如何处理？？？（不会由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
        /// <summary>
        /// Application_OnEnd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnEnd(Object sender, EventArgs e)
        {
            logger.InfoFormat("Application_OnEnd : {0}{1}", sender, Environment.NewLine);
            //var method = (MethodInfo)MethodBase.GetCurrentMethod();
            //logger.Info(method.DescInfo());

            //var stackTrace = new StackTrace(true);
            //logger.Info(Environment.NewLine + stackTrace.DescInfo() + Environment.NewLine);
            //该方法中发生异常如何处理？？？（不会由 Application_OnError 处理）
            //throw new Exception("测试异常！！！");
        }
    }
}
