using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CodeGenerator.Engine
{
    public class File : CodeBlock
    {
        public string FilePath { get; set; }

        public File(string name, string filePath)
                      : base(name, string.Empty)
        {
            FilePath = filePath;
            this.ContentReplace = GetContentFile();
        }

        public File(string name, string filePath, string elementsReplicate)
                       : base(name, string.Empty, string.Empty, elementsReplicate)
        {
            FilePath = filePath;
            this.ContentReplace = GetContentFile();
            this.ContentReplicate = this.ContentReplace;
        }

        public override string Replace()
        {
            string codeReplicated = string.Empty;
            string codeReplaced = string.Empty;
            //codeReplaced = this.Replace(this.ContentReplace);
            codeReplaced = this.ContentReplace;
            foreach (Template nodo in Elements)
            {
                //nodo.ContentReplace = codeReplaced;
                codeReplicated = nodo.Execute();
                if (string.IsNullOrEmpty(codeReplicated))
                {
                    codeReplicated = codeReplaced;
                }
                codeReplaced = codeReplaced.Replace(nodo.Name, codeReplicated);
            }            
            return codeReplaced;


        }

        public override string Replicate()
        {
            string codeReplaced = string.Empty;
            string codeReplicated = string.Empty;

            if (string.IsNullOrEmpty(this.ContentReplicate))
            {
                this.ContentReplicate = string.Empty;
            }

            if (ElementsReplicate.Contains("Entity"))
            {
                foreach (Entity entity in Workspace.entities)
                {
                    codeReplicated = this.Replicate(entity);

                    // rename el fileName            
                    string fileNme = Workspace.inputsConfiguration["GenerationFolder"].ToString() + FilePath;
                    string newFileName = this.Replace(fileNme, entity);
                    this.SaveFile(codeReplicated, newFileName);
                    codeReplaced = codeReplicated;
                }
                //codeReplaced = this.ContentReplace.Replace(this.ContentReplicate, codeReplicated);                

            }


            return codeReplaced;

        }

        public override string Execute()
        {            
            string textReplaced = string.Empty;     
            if (string.IsNullOrEmpty(ContentReplicate))
            {
                textReplaced = this.Replace();

                // rename el fileName            
                string fileNme = Workspace.inputsConfiguration["GenerationFolder"].ToString() + FilePath;
                string newFileName = this.Replace(fileNme);
                this.SaveFile(textReplaced, newFileName);
            }
            else
            {
                textReplaced = this.Replicate();
            }
            return textReplaced;
        }

        protected string GetContentFile()
        {
            string contenido = string.Empty;
            try
            {
                string filePath= Workspace.inputsConfiguration["WorkspaceFolder"].ToString()+ FilePath;
                System.IO.StreamReader sr = new System.IO.StreamReader(filePath);
                contenido = sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return contenido;
        }

        protected void SaveFile(string contenido, string fileName)
        {
            try
            {
                //string filePath = Workspace.inputsConfiguration["GenerationFolder"].ToString() + FilePath;
                // write file if exists or create it    
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
                
                System.IO.StreamWriter sw = new System.IO.StreamWriter(fileName);
                sw.Write(contenido);
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
       

        

    }
}

