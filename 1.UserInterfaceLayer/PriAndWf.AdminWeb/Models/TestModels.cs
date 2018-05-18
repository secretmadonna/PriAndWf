using System.Collections.Generic;

namespace PriAndWf.AdminWeb.Models
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