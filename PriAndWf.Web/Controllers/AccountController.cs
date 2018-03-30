using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriAndWf.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var vm = new Models.AccountViewModel()
            {
                SignUp = new Models.SignUpViewModel(),
                Login = new Models.LoginViewModel(),
                Forgot = new Models.ForgotViewModel()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginViewModel vm)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Forgot(Models.ForgotViewModel vm)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Models.SignUpViewModel vm)
        {
            return View();
        }
    }
}