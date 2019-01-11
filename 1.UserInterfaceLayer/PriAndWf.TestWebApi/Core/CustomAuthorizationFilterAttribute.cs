using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomAuthorizationFilterAttribute : AuthorizeAttribute
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            exceptionLogger.Info("CustomAuthorizationFilterAttribute.OnAuthorization");
            base.OnAuthorization(actionContext);
        }
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            exceptionLogger.Info("CustomAuthorizationFilterAttribute.OnAuthorizationAsync");
            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            exceptionLogger.Info("CustomAuthorizationFilterAttribute.HandleUnauthorizedRequest");
            base.HandleUnauthorizedRequest(actionContext);
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new CommonResponse()
            {
                ret = (int)RetCode.Unauthorized,
                msg = RetCode.Unauthorized.Description()
            });
        }
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            exceptionLogger.Info("CustomAuthorizationFilterAttribute.IsAuthorized");
            return true;
            return base.IsAuthorized(actionContext);
        }
    }
}