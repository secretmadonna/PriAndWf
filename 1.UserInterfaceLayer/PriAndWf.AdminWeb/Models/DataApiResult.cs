using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.AdminWeb.Models
{
    public class DataApiResult
    {
        public string RetCode { get; internal set; }
        public object RetData { get; internal set; }

        public DataApiResult() { }
        public DataApiResult(string code)
        {
            RetCode = code;
        }
        public DataApiResult(string code, object data)
        {
            RetCode = code;
            RetData = data;
        }

        public static DataApiResult SuccessResult(string code = "success")
        {
            return new DataApiResult(code);
        }
        public static DataApiResult FailResult(object data, int code)
        {
            return new DataApiResult(code.ToString(), data);
        }
        public static DataApiResult FailResult(int code = 0)
        {
            return FailResult(null, code);
        }
        public static DataApiResult FailResult(object data, DataApiResultCode code)
        {
            return FailResult(data, (int)code);
        }
        public static DataApiResult ExceptionResult(string message, string code = "exception")
        {
            return new DataApiResult(code, message);
        }
    }
    public enum DataApiResultCode
    {
        /// <summary>
        /// 模型验证未通过
        /// </summary>
        ModelValidNotPass = -999,
        Default = 0,
    }
}