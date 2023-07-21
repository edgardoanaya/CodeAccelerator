using SoftwareOne.BaseLine.Core.Entities;

namespace SoftwareOne.BaseLine.EntitiesDto
{
    /// <summary>
    /// Entity to manage the State entity
    /// </summary>
    public partial class State : BaseEntityDto
    {        
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } = null!;
    }
}