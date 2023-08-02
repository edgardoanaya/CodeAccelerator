using System;

namespace SoftwareOne.CodeAccelerator
{
    public class File : CodeBlock
    {
        public string FilePath { get; set; }

        public string FileName { get; set; }

        public File(string name)
                      : base(name, string.Empty)
        {
            FilePath = string.Empty;
            FileName = string.Empty;
            this.ContentReplace = string.Empty;
            this.ContentReplicate= string.Empty;
        }

        public  File(string name, string filePath)
                      : base(name, string.Empty)
        {
            FilePath = filePath;
            FileName = this.ExtractFileName(filePath);
            this.ContentReplace = GetContentFile();
        }

        public File(string name, string filePath, string elementsReplicate)
                       : base(name, string.Empty, string.Empty, elementsReplicate)
        {
            FilePath = filePath;
            FileName = this.ExtractFileName(filePath);
            this.ContentReplace = GetContentFile();
            this.ContentReplicate = this.ContentReplace;
        }

        public override string Replace()
        {
            string codeReplicated = string.Empty;
            string content = this.ContentReplace;
            string codeReplaced = this.ContentReplace;
            foreach (Template nodo in Elements)
            {
                codeReplicated = nodo.Execute();
                if (string.IsNullOrEmpty(codeReplicated))
                {
                    codeReplicated = codeReplaced;
                }
                content = codeReplaced;
                codeReplaced = content.Replace(nodo.Name, codeReplicated);
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
                    string fileNme = Workspace.workload.GenerationFolder + FilePath;
                    string newFileName = this.Replace(fileNme, entity);
                    this.SaveFile(codeReplicated, newFileName);
                    codeReplaced = codeReplicated;
                }               
            }
            return codeReplaced;
        }

        public override string Execute()
        {            
            string textReplaced = string.Empty;     
            if (string.IsNullOrEmpty(ContentReplicate))
            {
                textReplaced = this.Replace();

                string fileNme = Workspace.workload.GenerationFolder + FilePath;
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
                string workspaceFolder = Workspace.workload.GenerationFolder;
                if (FilePath.Contains(workspaceFolder))
                {
                    workspaceFolder = string.Empty;
                }
                string filePath= workspaceFolder + FilePath;
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

        public void SaveFile(string contenido, string fileName)
        {
            try
            {
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
        public void SaveFile(string contenido)
        {
            try
            {
                string fileName = Workspace.workload.GenerationFolder + FilePath;
                
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

        public void DeleteFile()
        {
            try
            {
                string fileName = Workspace.workload.GenerationFolder + FilePath;
                if (System.IO.File.Exists(fileName))
                {
                    System.IO.File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected string ExtractFileName(string path)
        {
            string[] pathSplit = path.Split('\\');
            return pathSplit[pathSplit.Length - 1];
        }





    }
}

