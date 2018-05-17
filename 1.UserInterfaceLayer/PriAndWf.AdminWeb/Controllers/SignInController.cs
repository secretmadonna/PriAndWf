using MyTestMvc.Extension;
using MyTestMvc.Models;
using MyTestMvc.Services;
using MyTestMvc.Services.ServiceModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace MyTestMvc.Controllers
{
    public class SignInController : Controller
    {
        ISignInService signInService = new SignInService();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestSignIn()
        {
            return View();
        }
        [HttpGet]
        public ActionResult SignIn(int? examBatchSessionId = null)
        {
            var canSignList = signInService.GetCanSignList();
            var currentCanSignSession = (examBatchSessionId.HasValue && canSignList.Any(m => m == examBatchSessionId.Value)) ? examBatchSessionId.Value : canSignList.FirstOrDefault();
            return View(currentCanSignSession);
        }
        [HttpPost]
        public ActionResult SignIn(SignInModel model)
        {
            Thread.Sleep(2000);
            if (!ModelState.IsValid)
            {
                return Json(DataApiResult.FailResult(ModelState.GetFirstValidNotPassMsg(), DataApiResultCode.ModelValidNotPass));
            }
            var result = 0;
            var sModel = new SignInSModel();
            signInService.SignIn(sModel);
            if (result > 0)
            {
                return Json(DataApiResult.SuccessResult());
            }
            return Json(DataApiResult.FailResult(result));
        }
        public ActionResult AutoSignIn(int? examBatchSessionId = null)
        {
            var canSignList = signInService.GetCanSignList();
            var currentCanSignSession = (examBatchSessionId.HasValue && canSignList.Any(m => m == examBatchSessionId.Value)) ? examBatchSessionId.Value : canSignList.FirstOrDefault();
            return View(currentCanSignSession);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                signInService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}