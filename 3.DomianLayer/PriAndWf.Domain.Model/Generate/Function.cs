namespace PriAndWf.Domain.Model
{
    partial class Function : Entity.Entity
    {
        public string Type { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public int SortIndex { get; set; }
        public string Remark { get; set; }
        public bool Active { get; set; }
        public string Url { get; set; }
    }
}
