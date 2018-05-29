using System;
using System.IO;
using System.Web;

namespace PriAndWf.AdminWeb.Handlers
{
    /// <summary>
    /// UploadifyHandler 的摘要说明
    /// </summary>
    public class UploadifyHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            var file = context.Request.Files["Filedata"];
            if (file != null)
            {
                var oldFileName = file.FileName;//文件名
                var fileExt = oldFileName.Substring(oldFileName.LastIndexOf("."));//文件后缀（带.）
                var fileSize = file.ContentLength;//文件大小

                var savePath = context.Server.MapPath("~/UploadFiles/");//保存路径
                var saveFileName = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + fileExt;//保存文件名

                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                file.SaveAs(savePath + saveFileName);//保存文件

                context.Response.Write(saveFileName);//响应
                return;
            }
            context.Response.Write("0");//响应
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}