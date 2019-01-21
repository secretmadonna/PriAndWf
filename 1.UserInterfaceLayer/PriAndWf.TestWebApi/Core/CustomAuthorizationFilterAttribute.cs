﻿using log4net;
using PriAndWf.Infrastructure.Extension;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    public class CustomAuthorizationFilterAttribute : AuthorizationFilterAttribute//System.Web.Http.AuthorizeAttribute
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
    }
}