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

        [HttpGet]
        public ActionResult Login()
        {
            LoginViewModel vm = new LoginViewModel()
            {
                LoginName = "duanf",
                PassWord = "123456"
            };
            return View(vm);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel vm)
        {
            FormsAuthentication.SetAuthCookie(vm.LoginName, vm.RememberMe);
            return Redirect(FormsAuthentication.DefaultUrl);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect(FormsAuthentication.DefaultUrl);
        }
    }
}