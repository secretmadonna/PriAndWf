using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.WebApi.Models
{
    public class ApiResult
    {
        public string Status { get; set; }
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string SubStatus { get; set; }
    }
}