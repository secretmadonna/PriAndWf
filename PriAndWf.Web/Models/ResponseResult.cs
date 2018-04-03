using System;

namespace PriAndWf.Web.Models
{
    [Serializable]
    public class ResponseResult
    {
        public bool Success
        {
            get { return string.IsNullOrEmpty(this.Code) || Code == "0"; }
        }
        /// <summary>
        /// 业务状态码
        /// </summary>
        public string Code { get; set; }
        public object Data { get; set; }

        public ResponseResult() { }
        public ResponseResult(string code = null, object data = null)
        {
            this.Code = code;
            this.Data = data;
        }

        public static ResponseResult Result(string code = null, object data = null)
        {
            return new ResponseResult(code, data);
        }
    }
}