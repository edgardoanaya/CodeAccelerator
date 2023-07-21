using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the City entity
    /// </summary>
    public partial class City : BaseEntityDto
    {
        
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } //{DefaultField}
    }
}