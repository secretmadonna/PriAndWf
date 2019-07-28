using System.Web.Mvc;

namespace PriAndWf.AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        [Route("Home/Index")]
        [Route("Home/TestIndex")]
        public ActionResult Index()
        {
            Session["RawUrl"] = Request.RawUrl;
            return View();
        }
    }
}