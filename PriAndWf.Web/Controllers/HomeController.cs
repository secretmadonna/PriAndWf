using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PriAndWf.Web.Controllers
{
    public class HomeController : Controller
    {
        private List<Models.TestModel1> list = new List<Models.TestModel1>();

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Test1()
        {
            var ran = new Random();
            var index = 1;
            for (int i = 1; i <= 20; i++)
            {
                var tempModelL1 = new Models.TestModel1() { Id = index, Name = "第 " + i + " 章", SortIndex = index, Children = new List<Models.TestModel1>() };
                for (int j = 1; j < ran.Next(2, 10); j++)
                {
                    index++;
                    var tempModelL2 = new Models.TestModel1() { Id = index, Name = "第 " + i + "." + j + " 节", SortIndex = index, ParentId = tempModelL1.Id, Parent = tempModelL1, Children = new List<Models.TestModel1>() };
                    for (int m = 1; m < ran.Next(1, 10); m++)
                    {
                        index++;
                        var tempModelL3 = new Models.TestModel1() { Id = index, Name = "第 " + i + "." + j + "." + m + " 小节", SortIndex = index, ParentId = tempModelL2.Id, Parent = tempModelL2 };
                        tempModelL2.Children.Add(tempModelL3);
                    }
                    tempModelL1.Children.Add(tempModelL2);
                }
                list.Add(tempModelL1);
            }
            return View(list);
        }
    }
}