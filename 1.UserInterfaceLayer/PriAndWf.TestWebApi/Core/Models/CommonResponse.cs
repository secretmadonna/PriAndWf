using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.TestWebApi.Core
{
    public class CommonResponse<T>
    {
        public int ret { get; set; }
        public string msg { get; set; }
        public T data { get; set; }
    }
}