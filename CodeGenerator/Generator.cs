using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Engine
{
    public class Generator
    {
        public List<Template> Rules { get; set; }

        public Generator()
        {           
            Rules = new List<Template> ();
        }

        public string ExcuteRules()
        {
            string result = string.Empty;
            foreach (Template rule in Rules)
            {
                result=rule.Execute();
            }
            return result;
        }

        //copy a folder
        public string Copyfolder(string source, string destination)
        {
            string result = string.Empty;
            try
            {
                if(System.IO.Directory.Exists(destination))
                {
                    System.IO.Directory.Delete(destination, true);
                }
                System.IO.Directory.CreateDirectory(destination);

                //Now Create all of the directories
                foreach (string dirPath in System.IO.Directory.GetDirectories(source, "*",
                                       System.IO.SearchOption.AllDirectories))
                    System.IO.Directory.CreateDirectory(dirPath.Replace(source, destination));

                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in System.IO.Directory.GetFiles(source, "*.*",
                                       System.IO.SearchOption.AllDirectories))
                    System.IO.File.Copy(newPath, newPath.Replace(source, destination), true);

                result= "Folder copied: " + destination;
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string DeleteFileRules(string generationFolder)
        {
            string result = string.Empty;
            string fileName = string.Empty;
            try
            {
                foreach (Template rule in Rules)
                {
                    if (rule is File)
                    {
                        File file = (File)rule;
                        if (!string.IsNullOrEmpty(file.FilePath) && file.FilePath.Contains("_Template"))
                        {
                            fileName = generationFolder + file.FilePath;
                            System.IO.File.Delete(fileName);
                            result = "File deleted: " + fileName;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }   

    }
}
