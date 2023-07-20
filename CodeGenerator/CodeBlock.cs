using System;
using System.Collections.Generic;

namespace CodeGenerator.Engine
{
    public class CodeBlock : Template
    {
        public List<Template> Elements;

        public string Name { get; set; }
        
        public string ContentReplicate { get; set; }
        public string ContentReplace { get; set ; }
        public string VariableNewText { get ; set ; }

        public string ElementsReplicate { get; set; }

        public CodeBlock(string name, string contentReplace)
        {
            Elements = new List<Template>();
            Name = name;            
            ContentReplace = contentReplace;
            ContentReplicate = string.Empty;
            ElementsReplicate = string.Empty;

        }

        public CodeBlock(string name, string contentReplace, string contentReplicate, string elementsReplicate)
        {
            Elements = new List<Template>();
            Name = name;
            ContentReplace = contentReplace;
            ContentReplicate = contentReplicate;
            ElementsReplicate = elementsReplicate;

        }

        public void AddElement(Template elemento)
        {
            Elements.Add(elemento);
        }

        public void DeleteElement(Template elemento)
        {
            Elements.Remove(elemento);
        }

        public Template Get(string nombre)
        {
            if (this.Name.ToUpper() == nombre.ToUpper())
            {
                return this;
            }
            else
            {
                Template temporal;
                foreach (Template elemento in Elements)
                {
                    temporal = elemento.Get(nombre);
                    if (temporal != null)
                    {
                        return temporal;
                    }
                }
            }
            return null;
        }

        public string Rename()
        {
            throw new NotImplementedException();
        }

        public virtual string Replace()
        {

            foreach (Template elemento in Elements)
            {
                elemento.ContentReplace = this.ContentReplace;
                this.ContentReplace = elemento.Replace();
            }
            return ContentReplace;

        }

        public string Replace(string contenido)
        {
            string codeReplaced = contenido;

            foreach (Template elemento in Elements)
            {
                elemento.ContentReplace = codeReplaced;
                codeReplaced = elemento.Replace();
            }
            return codeReplaced;

        }

        public string Replace(object entity)
        {
            return this.Replace(this.ContentReplace, entity);
        }

        public string Replace(string contenido, object entity)
        {
            string codeReplaced = contenido;

            foreach (Template elemento in Elements)
            {
                if (elemento is Variable)
                {
                    codeReplaced = elemento.Replace(codeReplaced, entity);
                }
                
            }
            return codeReplaced;

        }

        public virtual string Replicate()
        {
            string codeReplaced = string.Empty;
            string codeReplicated = string.Empty;

            if (string.IsNullOrEmpty(this.ContentReplicate))
            {
                this.ContentReplicate = string.Empty;
            }

            if(ElementsReplicate.Contains("Entity"))
            {
                foreach (Entity entity in Workspace.entities)
                {
                    //codeReplaced = Replicate(entity);
                    codeReplicated += Replicate(entity);

                }
                codeReplaced = this.ContentReplace.Replace(this.ContentReplicate, codeReplicated);
            }           
                        

            return codeReplaced;

        }

        protected string Replicate(Entity entity)
        {
            string codeReplicated = string.Empty;
            string codeReplaced = this.Replace(this.ContentReplicate, entity);
            foreach (Template nodo in Elements)
            {
                nodo.ContentReplace = codeReplaced;
                codeReplicated += nodo.Replicate(entity.Fields);
            }

            if(string.IsNullOrEmpty(codeReplicated))
            {
                codeReplicated = codeReplaced;
            }
            codeReplaced = this.ContentReplace.Replace(this.ContentReplicate, codeReplicated);
            return codeReplaced;
        }

        public string Replicate(List<Field> list)
        {
            string codeReplaced = string.Empty;
            string codeReplicated = string.Empty;

            if (string.IsNullOrEmpty(ContentReplicate))
            {
                this.ContentReplicate = string.Empty;
            }

            if (ElementsReplicate.Contains("Field"))
            {
                foreach (Field elemento in list)
                {

                    codeReplaced = this.Replace(this.ContentReplicate, elemento);
                    codeReplicated += codeReplaced;
                    foreach (Template nodo in Elements)
                    {
                        codeReplicated += nodo.Replicate();
                    }                    
                }
                codeReplaced = this.ContentReplace.Replace(this.ContentReplicate, codeReplicated);
            }           

            return codeReplaced;

        }

        public virtual string Execute()
        {
            string textReplaced = string.Empty;
            if (string.IsNullOrEmpty(ContentReplicate))
            {
                textReplaced = this.Replace();
            }
            else
            {
                textReplaced = this.Replicate();
            }
            return textReplaced;
        }



    }
}

