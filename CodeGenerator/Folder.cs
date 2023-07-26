using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Engine
{
    public class Folder : File
    {
        public string SearchPattern { get; set; }

        public Folder(string name, string filePath) : base(name)
        {
            //FilePath = filePath;
            //this.ContentReplace = GetContentFile();
            FilePath = Workspace.inputsConfiguration["WorkspaceFolder"].ToString() + filePath;
        }

        public Folder(string name, string filePath,string searchPattern) : base(name)
        {
            SearchPattern = searchPattern;
            FilePath = Workspace.inputsConfiguration["WorkspaceFolder"].ToString() + filePath;
        }

        public override string Execute()
        {
            string textReplaced = string.Empty;
            List<Template> Rules = this.GetFiles();
            
            foreach (File nodo in Rules)
            {
                textReplaced = nodo.ContentReplace;
                foreach (Template elemento in this.Elements)
                {
                    if(elemento is Variable)
                    {
                        Variable variable = (Variable)elemento;
                        variable.ContentReplace = textReplaced;
                        textReplaced=variable.Replace();
                    }
                }
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
                string workspaceFolder = Workspace.inputsConfiguration["WorkspaceFolder"].ToString();

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
    }
}

