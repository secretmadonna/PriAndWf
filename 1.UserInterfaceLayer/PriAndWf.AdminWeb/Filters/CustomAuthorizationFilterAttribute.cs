using log4net;
using System.Web.Mvc;

namespace PriAndWf.AdminWeb.Filters
{
    public class CustomAuthorizationFilterAttribute : FilterAttribute, IAuthorizationFilter, IMvcFilter
    {
        private ILog exceptionLogger = LogManager.GetLogger("ExceptionLogger");

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            exceptionLogger.Info("CustomAuthorizationFilterAttribute.OnAuthorization");
            throw new System.NotImplementedException();
        }
    }
}