using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomAuthorizationFilterAttribute : AuthorizationFilterAttribute//System.Web.Http.AuthorizeAttribute
    {
        private ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            base.OnAuthorization(actionContext);
        }
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var method = (MethodInfo)MethodBase.GetCurrentMethod();
            logger.Info(method.DescInfo());

            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
}