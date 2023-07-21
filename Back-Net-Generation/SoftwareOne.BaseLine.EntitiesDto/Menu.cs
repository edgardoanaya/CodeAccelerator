using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    public partial class Menu : BaseEntityDto
    {
        public string? Path { get; set; }
        public string? Title { get; set; }
        public string? Icon { get; set; }
        public string? Class { get; set; }
        public string? Badge { get; set; }
        public string? BadgeClass { get; set; }
        public bool IsExternalLink { get; set; }
        public bool IsParent { get; set; }
        public List<Menu>? SubMenu { get; set; } = null!;
        public int? MenuId { get; set; }
    }
}