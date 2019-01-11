using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.TestWebApi.Core
{
    public class CommonResponse
    {
        public int ret { get; set; }
        public string msg { get; set; }
    }
    public class CommonResponse<T> : CommonResponse
    {
        public T data { get; set; }
    }
}