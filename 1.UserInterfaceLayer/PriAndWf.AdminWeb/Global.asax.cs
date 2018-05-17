using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace PriAndWf.AdminWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }


        public ILog staticLogger = LogManager.GetLogger("staticLogger");
        public static int numberIndex = 0;

        public override void Init()
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
            base.Init();
        }

        protected void Application_OnStart(Object sender, EventArgs e)
        {
            numberIndex = 0;
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_OnEnd(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Session_OnEnd(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1} {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, Session.SessionID);
        }

        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_OnError(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1:yyyy-MM-dd HH:mm:ss}  {2}", ++numberIndex, DateTime.Now, MethodBase.GetCurrentMethod().Name);
        }
        /// <summary>
        /// 哪儿被调用？
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_OnStart(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1} {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, Session.SessionID);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1} {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, Request.RawUrl);
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_AuthorizeRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAuthorizeRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_ResolveRequestCache(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostResolveRequestCache(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_MapRequestHandler(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostMapRequestHandler(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_AcquireRequestState(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostAcquireRequestState(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_ReleaseRequestState(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostReleaseRequestState(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_UpdateRequestCache(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostUpdateRequestCache(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_LogRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PostLogRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1} {2}", ++numberIndex, MethodBase.GetCurrentMethod().Name, Request.RawUrl);
        }
        protected void Application_PreSendRequestHeaders(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
        protected void Application_PreSendRequestContent(Object sender, EventArgs e)
        {
            staticLogger.InfoFormat("{0:D3}.{1}", ++numberIndex, MethodBase.GetCurrentMethod().Name);
        }
    }
}
