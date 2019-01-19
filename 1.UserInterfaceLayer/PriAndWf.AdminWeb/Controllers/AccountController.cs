using PriAndWf.AdminWeb.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace PriAndWf.AdminWeb.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="returnUrl">是否存在编码问题？？？</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            LoginViewModel vm = new LoginViewModel()
            {
                LoginName = "duanf",
                PassWord = "123456"
            };
            return View(vm);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vm"></param>
        /// <param name="returnUrl">是否存在编码问题？？？</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel vm, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(vm.LoginName, vm.RememberMe);
            if (Session != null)
            {
                Session["LoginName"] = vm.LoginName;
            }
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(FormsAuthentication.DefaultUrl);
            }
            return Redirect(returnUrl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}