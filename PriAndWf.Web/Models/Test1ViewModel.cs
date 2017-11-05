using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.Web.Models
{
    public class Test1ViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortIndex { get; set; }
        public int? ParentId { get; set; }
        public Test1ViewModel Parent { get; set; }
        public List<Test1ViewModel> Children { get; set; }
    }
}