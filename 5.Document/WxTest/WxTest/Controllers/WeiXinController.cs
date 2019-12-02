using Senparc.Weixin;
using Senparc.Weixin.MP;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace WxTest.Controllers
{
    public class WeiXinController : Controller
    {
        private string appId = Config.SenparcWeixinSetting.WeixinAppId;
        private string appSecret = Config.SenparcWeixinSetting.WeixinAppSecret;

        //GET: WeiXin
        [HttpGet]
        public ActionResult Index(string signature, string timestamp, string nonce, string echostr)
        {
            if (CheckSignature.Check(signature, timestamp, nonce))
            {
                return Content(echostr);//返回随机字符串则表示验证通过
            }
            return Content("failed:" + signature + "," + CheckSignature.GetSignature(timestamp, nonce) + "。如果您在浏览器中看到这条信息，表明此Url可以填入微信后台。");
        }

        public ActionResult JsSDK()
        {
            var url = Request.Url.AbsoluteUri;
            var jsSdkUiPackage = JSSDKHelper.GetJsSdkUiPackage(appId, appSecret, url);
            return View(jsSdkUiPackage);
        }

        [HttpPost]
        public JsonResult SaveImageToServer(string[] mediaIds)
        {
            var dir = Server.MapPath("~/Upload/Weixin");
            var urls = new List<string>();
            foreach (var mediaId in mediaIds)
            {
                var fullFileName = MediaApi.Get(appId, mediaId, dir);
                var fileName = Path.GetFileName(fullFileName);
                var url = string.Format("{0}://{1}{2}{3}", Request.Url.Scheme, Request.Url.Authority, Url.Content("~/Upload/"), fileName);
                urls.Add(url);
            }
            var data = new { urls = urls };
            return Json(data);
        }
    }
}