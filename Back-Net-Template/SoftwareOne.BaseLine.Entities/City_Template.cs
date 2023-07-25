using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SoftwareOne.BaseLine.Entities
{
    /// <summary>
    /// Entity to manage the City entity
    /// </summary>
    public partial class City : Core.Entities.BaseEntity, Core.Entities.IEntity
    {
        /// <summary>
        /// Property to manage the Operation field
        /// </summary>
        //{DecoratorField}
        public string Operation { get; set; } //{DefaultField}

    }
}

