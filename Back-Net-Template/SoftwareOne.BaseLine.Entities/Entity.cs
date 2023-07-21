namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the Entity entity
    /// </summary>
    public partial class Entity : Core.Entities.BaseEntity, Core.Entities.IEntity
    {

        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } = null!;
    }
}