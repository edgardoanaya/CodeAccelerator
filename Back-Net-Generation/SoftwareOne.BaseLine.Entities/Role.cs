namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the Role entity
    /// </summary>
    public partial class Role : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Property to manage the Menus field
        /// </summary>
        public List<Menu> Menus { get; set; } = null!;
    }
}