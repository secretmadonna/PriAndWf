using MyTestMvc.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MyTestMvc.Controllers
{
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test1()
        {
            var list = new List<Test1ViewModel>();

            var ran = new Random();
            var index = 1;
            for (int i = 1; i <= 20; i++)
            {
                var tempModelL1 = new Test1ViewModel() { Id = index, Name = "第 " + i + " 章", SortIndex = index, Children = new List<Models.Test1ViewModel>() };
                for (int j = 1; j < ran.Next(2, 10); j++)
                {
                    index++;
                    var tempModelL2 = new Test1ViewModel() { Id = index, Name = "第 " + i + "." + j + " 节", SortIndex = index, ParentId = tempModelL1.Id, Parent = tempModelL1, Children = new List<Models.Test1ViewModel>() };
                    for (int m = 1; m < ran.Next(1, 10); m++)
                    {
                        index++;
                        var tempModelL3 = new Test1ViewModel() { Id = index, Name = "第 " + i + "." + j + "." + m + " 小节", SortIndex = index, ParentId = tempModelL2.Id, Parent = tempModelL2 };
                        tempModelL2.Children.Add(tempModelL3);
                    }
                    tempModelL1.Children.Add(tempModelL2);
                }
                list.Add(tempModelL1);
            }
            return View(list);
        }

        public ActionResult Test2()
        {
            return View();
        }

        public ActionResult Test3()
        {
            return View();
        }

        public ActionResult Test4()
        {
            return View();
        }

        public ActionResult Test5()
        {
            return View();
        }

        public ActionResult Test6()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test6(string keyWords)
        {
            return View();
        }
    }
}