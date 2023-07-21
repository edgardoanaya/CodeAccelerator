namespace SoftwareOne.BaseLine.Entities
{
    public partial class Menu : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        public string? Path { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Class { get; set; }
        public string? Badge { get; set; }
        public string? BadgeClass { get; set; }
        public bool IsExternalLink { get; set; }
        public bool IsParent { get; set; }
        public List<Menu> SubMenu { get; set; } = null!;
        public int? MenuId { get; set; }
        public List<Role> Roles { get; set; } = null!;
    }
}