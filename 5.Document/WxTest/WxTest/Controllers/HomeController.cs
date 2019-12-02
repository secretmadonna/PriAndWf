using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WxTest.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test1()
        {
            var pickerItems = new List<PickerItem>();
            var pickerItem1 = new PickerItem() { value = "110000", label = "北京市", disabled = false, children = new List<PickerItem>() };
            var pickerItem11 = new PickerItem() { value = "110101", label = "东城区", disabled = false, children = new List<PickerItem>() };
            var pickerItem12 = new PickerItem() { value = "110102", label = "西城区", disabled = false, children = new List<PickerItem>() };
            pickerItem1.children.Add(pickerItem11);
            pickerItem1.children.Add(pickerItem12);
            var pickerItem2 = new PickerItem() { value = "120000", label = "天津市", disabled = false, children = new List<PickerItem>() };
            var pickerItem21 = new PickerItem() { value = "120101", label = "和平区", disabled = false, children = new List<PickerItem>() };
            var pickerItem22 = new PickerItem() { value = "120102", label = "河西区", disabled = false, children = new List<PickerItem>() };
            pickerItem2.children.Add(pickerItem21);
            pickerItem2.children.Add(pickerItem22);
            var pickerItem3 = new PickerItem() { value = "130000", label = "河北省", disabled = false, children = new List<PickerItem>() };
            var pickerItem31 = new PickerItem() { value = "130100", label = "石家庄市", disabled = false, children = new List<PickerItem>() };
            var pickerItem311 = new PickerItem() { value = "130102", label = "长安区", disabled = false, children = new List<PickerItem>() };
            var pickerItem312 = new PickerItem() { value = "130103", label = "桥西区", disabled = false, children = new List<PickerItem>() };
            pickerItem31.children.Add(pickerItem311);
            pickerItem31.children.Add(pickerItem312);
            var pickerItem32 = new PickerItem() { value = "130200", label = "唐山市", disabled = false, children = new List<PickerItem>() };
            var pickerItem321 = new PickerItem() { value = "130202", label = "路南区", disabled = false, children = new List<PickerItem>() };
            var pickerItem322 = new PickerItem() { value = "130203", label = "路北区", disabled = false, children = new List<PickerItem>() };
            pickerItem32.children.Add(pickerItem321);
            pickerItem32.children.Add(pickerItem322);
            pickerItem3.children.Add(pickerItem31);
            pickerItem3.children.Add(pickerItem32);
            var pickerItem4 = new PickerItem() { value = "140000", label = "山西省", disabled = false, children = new List<PickerItem>() };
            var pickerItem41 = new PickerItem() { value = "140100", label = "太原市", disabled = false, children = new List<PickerItem>() };
            var pickerItem411 = new PickerItem() { value = "140105", label = "小店区", disabled = false, children = new List<PickerItem>() };
            var pickerItem412 = new PickerItem() { value = "140106", label = "迎泽区", disabled = false, children = new List<PickerItem>() };
            pickerItem41.children.Add(pickerItem411);
            pickerItem41.children.Add(pickerItem412);
            var pickerItem42 = new PickerItem() { value = "140200", label = "大同市", disabled = false, children = new List<PickerItem>() };
            var pickerItem421 = new PickerItem() { value = "140202", label = "新荣区", disabled = false, children = new List<PickerItem>() };
            var pickerItem422 = new PickerItem() { value = "140203", label = "平城区", disabled = false, children = new List<PickerItem>() };
            pickerItem42.children.Add(pickerItem421);
            pickerItem42.children.Add(pickerItem422);
            pickerItem4.children.Add(pickerItem41);
            pickerItem4.children.Add(pickerItem42);
            var pickerItem5 = new PickerItem() { value = "810000", label = "香港特别行政区", disabled = false, children = new List<PickerItem>() };
            var pickerItem6 = new PickerItem() { value = "820000", label = "澳门特别行政区", disabled = false, children = new List<PickerItem>() };
            pickerItems.Add(pickerItem1);
            pickerItems.Add(pickerItem2);
            pickerItems.Add(pickerItem3);
            pickerItems.Add(pickerItem4);
            pickerItems.Add(pickerItem5);
            pickerItems.Add(pickerItem6);
            ViewBag.PickerItems = pickerItems;
            return View();
        }
        [HttpPost]
        public ActionResult Test1(Travel model)
        {
            return Json(model);
        }
    }

    public class Travel
    {
        public string DCityId { get; set; }
        [Display(Name = "出发地")]
        public string DCityName { get; set; }
        public string ACityId { get; set; }
        [Display(Name = "目的地")]
        public string ACityName { get; set; }

        public ICollection<TravelDetail> TravelDetails { get; set; }
    }
    public class TravelDetail
    {
        public string DCityId { get; set; }
        public string DCityDetail { get; set; }
        public string ACityId { get; set; }
        public string ACityDetail { get; set; }
        public DateTime DDateTime { get; set; }
        public DateTime ADateTime { get; set; }
        public string AirplaneCompany { get; set; }
        public string AirplaneNo { get; set; }
        public string Remark { get; set; }
    }


    public class PickerItem
    {
        public string value { get; set; }
        public string label { get; set; }
        public bool disabled { get; set; }
        public ICollection<PickerItem> children { get; set; }
    }
}