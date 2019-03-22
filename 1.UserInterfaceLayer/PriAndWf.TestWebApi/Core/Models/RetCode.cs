using System.ComponentModel;

namespace PriAndWf.TestWebApi.Core
{
    public enum RetCode
    {
        [Description("处理成功")]
        OK = 0,
        [Description("未授权")]
        Unauthorized = 401,
    }
}