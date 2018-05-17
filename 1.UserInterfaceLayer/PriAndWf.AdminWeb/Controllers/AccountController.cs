using System.Web.Mvc;

namespace MyTestMvc.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}