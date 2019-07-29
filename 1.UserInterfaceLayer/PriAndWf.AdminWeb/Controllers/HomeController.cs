using System.Web.Mvc;

namespace PriAndWf.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["RawUrl"] = Request.RawUrl;
            return View();
        }
    }
}