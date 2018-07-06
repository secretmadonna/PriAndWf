namespace PriAndWf.Domain.Model
{
    partial class Menu : Entity.Entity
    {
        public string Type { get; set; }
        public int ParentId { get; set; }
        public string Icon { get; set; }
        public string Name { get; set; }
        public int SortIndex { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
        public int? MouduleId { get; set; }
    }
}
