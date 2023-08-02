using System.Collections.Generic;

namespace SoftwareOne.CodeAccelerator
{
    public class Entity
    {
        /// <summary>
        /// Property to manage the Name field
        /// </summary>
        public string Name { get; set; } = string.Empty;

        public List<Field> Fields { get; set; }

        public string OrderDefault { get; set; } = string.Empty;

        public Entity(string name)
        {
            this.Name = name;
            this.Fields = new List<Field>();
        }

        public Entity(string name, List<Field> fields)
        {
            this.Name = name;
            this.Fields = fields;
        }

        public Entity(string name, string orderDefault)
        {
            this.Name = name;
            this.Fields = new List<Field>();
            this.OrderDefault = orderDefault;
        }
    }
}
