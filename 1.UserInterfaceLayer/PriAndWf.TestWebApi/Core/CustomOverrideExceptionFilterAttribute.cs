using System;
using System.Web.Http.Filters;

namespace PriAndWf.TestWebApi.Core
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class CustomOverrideExceptionFilterAttribute : Attribute, IOverrideFilter
    {
        public Type FiltersToOverride { get { return typeof(IExceptionFilter); } }

        public bool AllowMultiple { get { return false; } }
    }
}