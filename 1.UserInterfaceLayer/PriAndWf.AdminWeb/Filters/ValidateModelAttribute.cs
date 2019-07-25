using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PriAndWf.AdminWeb.Filters
{
    public class ValidateModelAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var modelState = ((Controller)filterContext.Controller).ModelState;
            if (!modelState.IsValid )
            {
                filterContext.Result = new ContentResult() { Content="",};
                //controller.Request
                //var firstErrorField = modelState.FirstOrDefault();
                //firstErrorField.
                //actionContext.Response = actionContext.Request.CreateErrorResponse(
                //    HttpStatusCode.BadRequest, actionContext.ModelState);
            }
        }
    }
}