using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PriAndWf.Web.Models
{
    public class TestModel1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortIndex { get; set; }
        public int? ParentId { get; set; }
        public TestModel1 Parent { get; set; }
        public List<TestModel1> Children { get; set; }
    }
}