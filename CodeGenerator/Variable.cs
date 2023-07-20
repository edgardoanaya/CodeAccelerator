using System;
using System.Collections.Generic;

namespace CodeGenerator.Engine
{
    public class Variable : Template
    {
        
        public string Name { get; set; }
        
        public string ContentReplicate { get; set; }

        public string ContentReplace { get; set; }

        public string VariableNewText { get; set; }

        


        public Variable(string name, string contentReplace, string variableNewText) 
        { 
            Name = name;
            ContentReplicate = string.Empty;
            ContentReplace = contentReplace;
            VariableNewText = variableNewText;
        }

        public void AddElement(Template elemento)
        {
            throw new NotImplementedException();
        }

        public void DeleteElement(Template elemento)
        {
            throw new NotImplementedException();
        }

        public Template Get(string nombre)
        {
            if (this.Name.ToUpper() == nombre.ToUpper())
            {
                return this;
            }
            return null;
        }

        public string Rename()
        {
            string textReplaced = string.Empty;

            
            return textReplaced;
        }

        public string Replace()
        {
            string textReplaced = this.ContentReplace;
            string valueVariable = string.Empty;
            
            if (Workspace.inputsConfiguration.TryGetValue(this.VariableNewText, out valueVariable))
            {
                valueVariable = Workspace.inputsConfiguration[this.VariableNewText];
                textReplaced = ContentReplace.Replace(this.Name, valueVariable);
            }
            
            return textReplaced;
        }

        public virtual string Replace(string contenido, object entity)
        {
            string textReplaced = contenido;
            string valueVariable = string.Empty;

            if (this.VariableNewText.Contains("{Entity.") && entity != null)
            {
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string propertyName = "{Entity." + property.Name + "}";
                    if (this.VariableNewText == propertyName)
                    {
                        valueVariable =property.GetValue(entity).ToString();
                        textReplaced = contenido.Replace(this.Name, valueVariable);
                        return textReplaced;
                    }
                }
            }

            if (this.VariableNewText.Contains("{Field.") && entity != null)
            {
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string propertyName = "{Field." + property.Name + "}";
                    if (this.VariableNewText.ToUpper() == propertyName.ToUpper())
                    {
                        valueVariable = property.GetValue(entity).ToString();
                        textReplaced = contenido.Replace(this.Name, valueVariable);
                        return textReplaced;
                    }
                }
            }

            if (Workspace.inputsConfiguration.TryGetValue(this.VariableNewText, out valueVariable))
            {
                valueVariable = Workspace.inputsConfiguration[this.VariableNewText];
                textReplaced = contenido.Replace(this.Name, valueVariable);
            }

            return textReplaced;
        }

        public string Replicate()
        {
            return string.Empty;
        }

        public string Replicate(List<Field> list)
        {
            return string.Empty;
        }

        public string Execute()
        {           
            return this.Replace();
        }
    }
}

