using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    public class Field
    {
        public string Name { get; set; } 

        public string Type { get; set; }

        public string Default { get; set; } = string.Empty;
        
        /// <summary>
        /// Name de la tabla a la que hace referencia
        /// </summary>
        public string ForeignKey { get; set; } = string.Empty;

        public string Decorator { get; set; } = string.Empty;

        public string MaxLength { get; set; } = string.Empty;

        public bool IsRequired { get; set; } = false;

        public string Precision { get; set; } = string.Empty;


        public Field(string name, string type, string constant)
        {
            Name = name;
            Type = type;
            Default = constant;            
            ForeignKey = string.Empty;
            Decorator = string.Empty;
        }

        public Field(string name, string type, string constant, string foreignKey)
        {
            Name = name;
            Type = type;
            Default = constant;
            ForeignKey = foreignKey;
            Decorator = string.Empty;
        }

        public Field(string name, string type, string constant, string foreignKey, string decorator)
        {
            Name = name;
            Type = type;
            Default = constant;
            ForeignKey = foreignKey;
            Decorator = decorator;            
        }

        public Field(string name, string type, string constant, string foreignKey, string decorator, string maxLength)
        {
            Name = name;
            Type = type;
            Default = constant;
            ForeignKey = foreignKey;
            Decorator = decorator;
            MaxLength = maxLength;
        }

        public Field(string name, string type, string constant, string foreignKey, string decorator, string maxLength, bool isRequired)
        {
            Name = name;
            Type = type;
            Default = constant;
            ForeignKey = foreignKey;
            Decorator = decorator;
            MaxLength = maxLength;
            IsRequired = isRequired;
        }

        public Field(string name, string type, string constant, string foreignKey, string decorator, string maxLength, bool isRequired, string precision)
        {
            Name = name;
            Type = type;
            Default = constant;
            ForeignKey = foreignKey;
            Decorator = decorator;
            MaxLength = maxLength;
            IsRequired = isRequired;
            Precision = precision;
        }

    }
}
