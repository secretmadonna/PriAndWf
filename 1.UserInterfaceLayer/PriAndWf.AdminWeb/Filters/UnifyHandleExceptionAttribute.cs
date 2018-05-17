using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyTestMvc.Filters
{
    public class UnifyHandleExceptionAttribute : FilterAttribute, IExceptionFilter//HandleErrorAttribute
    {
        public static Queue<Exception> ExceptionQueue = new Queue<Exception>();

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }
            var exception = filterContext.Exception;
            ExceptionQueue.Enqueue(exception);
            filterContext.ExceptionHandled = true;
            var isAjaxRequest = filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
            if (isAjaxRequest)
            {
                
            }
            filterContext.HttpContext.Response.Redirect("/Error.html");
        }
    }
}