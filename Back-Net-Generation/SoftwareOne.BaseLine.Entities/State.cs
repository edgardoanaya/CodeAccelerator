using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the State entity
    /// </summary>
    public partial class State : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        
        public string Name { get; set; } = null!;

    }
}

