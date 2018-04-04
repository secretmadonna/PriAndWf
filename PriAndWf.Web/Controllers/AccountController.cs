using System.Web.Mvc;

namespace PriAndWf.Web.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            var vm = new Models.AccountViewModel()
            {
                SignUpViewModel = new Models.SignUpViewModel(),
                LoginViewModel = new Models.LoginViewModel(),
                ForgotViewModel = new Models.ForgotViewModel()
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Models.LoginViewModel vm, bool RememberMe = false, string ReturnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Json(ModelState);
            }
            return Json(null);
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