﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriAndWf.Web.Filters
{
    public class UnifyHandleExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var isAjaxRequest=filterContext.RequestContext.HttpContext.Request.IsAjaxRequest();
            if (isAjaxRequest)
            {

            }
            filterContext.ExceptionHandled = true;
            //filterContext.
        }
    }
}