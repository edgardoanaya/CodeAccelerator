using System;
using System.Collections.Generic;

namespace SoftwareOne.CodeAccelerator
{
    public class Folder : File
    {
        public string SearchPattern { get; set; }

        public bool RenameDirectories { get; set; }

        public Folder(string name, string filePath) : base(name)
        {
            FilePath = Workspace.workload.GenerationFolder + filePath;
            FileName = this.ExtractFileName(filePath);
        }

        public Folder(string name, string filePath,string searchPattern) : base(name)
        {
            SearchPattern = searchPattern;
            FilePath = Workspace.workload.GenerationFolder + filePath;
            FileName = this.ExtractFileName(filePath);
        }

        public Folder(string name, string filePath, string searchPattern, bool renameDirectories)
            : base(name)
        {
            SearchPattern = searchPattern;
            FilePath = Workspace.workload.GenerationFolder + filePath;
            this.ContentReplace = string.Empty;
            this.ContentReplicate = string.Empty;
            this.RenameDirectories = renameDirectories;
            FileName = this.ExtractFileName(filePath);
        }

        public override string Execute()
        {
            if (this.RenameDirectories)
                return this.Rename();
            else
                return ReplaceFiles();
        }

        private string ReplaceFiles()
        {
            string textReplaced = string.Empty;
            string newFileName = string.Empty;
            List<Template> Rules = this.GetFiles();
           
            foreach (File nodo in Rules)
            {
                textReplaced = nodo.ContentReplace;
                newFileName = nodo.FileName;
                foreach (Template elemento in this.Elements)
                {
                    if (elemento is Variable)
                    {
                        Variable variable = (Variable)elemento;
                        variable.ContentReplace = textReplaced;
                        textReplaced = variable.Replace();

                        variable.ContentReplace = newFileName;
                        newFileName = variable.Replace();
                    }
                }
                nodo.DeleteFile();
                nodo.FilePath = nodo.FilePath.Replace(nodo.FileName, newFileName);
                nodo.SaveFile(textReplaced);
                
            }
            return textReplaced;
        }



        public List<Template> GetFiles()
        {
            string path = this.FilePath;
            string result = string.Empty;
            string fileName = string.Empty;
            List<Template> Rules = new List<Template>();
            File fileRule = new File("File");

            try
            {
                string workspaceFolder = Workspace.workload.GenerationFolder;

                string[] files = System.IO.Directory.GetFiles(path, SearchPattern
                    , System.IO.SearchOption.AllDirectories);
                foreach (string file in files)
                {
                    fileName = file.Replace(workspaceFolder, "");
                    result += fileName + "\n";
                    fileRule= new File(fileName, fileName);
                    Rules.Add(fileRule);
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return Rules;
        }

        public override string Rename()
        {
            string path = this.FilePath;
            string result = string.Empty;
            string fileName = string.Empty;
            string textReplaced = string.Empty;

            try
            {
                string workspaceFolder = Workspace.workload.GenerationFolder;

                string[] sourceDirectories = System.IO.Directory.GetDirectories(path,"*"
                    , System.IO.SearchOption.AllDirectories);
                foreach (string sourceDirectory in sourceDirectories)
                {
                    textReplaced = sourceDirectory;
                    foreach (Template elemento in this.Elements)
                    {
                        if (elemento is Variable)
                        {
                            Variable variable = (Variable)elemento;
                            variable.ContentReplace = textReplaced;
                            textReplaced = variable.Replace();
                        }
                    }
                    if(sourceDirectory != textReplaced)
                    System.IO.Directory.Move(sourceDirectory, textReplaced);

                }
            }
            catch (Exception ex)
            {
                textReplaced = ex.Message;
            }
            return textReplaced;
        }

        


    }
}

