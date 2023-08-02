using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace SoftwareOne.CodeAccelerator
{
    public class Generator
    {
        public List<Template> Rules { get; set; }

        public Generator(Workload workload)
        {           
            Rules = new List<Template> ();
            Workspace.Initialize();
            Workspace.workload = workload;
        }

        public string Execute(string workloadType)
        {
            string result = string.Empty;
            try
            {
                
                Workspace.LoadEntities();
                //result = this.SaveFileEntities();

                //string sourceFolder = Workspace.workload.TemplateFolder;
                //string destinatioFolder = Workspace.workload.GenerationFolder;
                //result += this.Copyfolder(sourceFolder, destinatioFolder);

                RulesGenerator rulesGenerator = new RulesGenerator(workloadType);
                this.Rules = rulesGenerator.GetRules();
                result += this.Rules.ToString();

                result += this.ExcuteRules();
                                
                result += this.DeleteFileTemplates("*_Template.*");

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;

        }

        public string ExcuteRules()
        {
            string result = string.Empty;
            foreach (Template rule in Rules)
            {
                rule.Execute();
                result += "Excute Rule: " + rule.Name + "\n";
            }
            return result;
        }
              
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
                            result += "File deleted: " + fileName;
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

        public string DeleteFileTemplates(string searchPattern)
        {
            string result = string.Empty;
            
            try
            {
                string[] files = System.IO.Directory.GetFiles(Workspace.workload.TemplateFolder, searchPattern
                    , System.IO.SearchOption.AllDirectories);
                foreach (string file in files)
                {                    
                    System.IO.File.Delete(file);
                    result += "File deleted: " + file;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string SaveFileEntities()
        {
            string result = string.Empty;
            string fileName = string.Empty;
            string json = string.Empty;
            try
            {
                foreach (Entity entity in Workspace.entities)
                {
                    json = JsonSerializer.Serialize(entity);
                    fileName= Workspace.workload.EntitiesFolder + entity.Name + ".json";
                    System.IO.File.WriteAllText(fileName, json);
                    result += "File saved: " + fileName;
                }
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public void DownloadZipFile(string url, string destinationPath)
        {
            url = @"https://github.com/edgardoanaya/CodeAccelerator/archive/refs/heads/main.zip";
            destinationPath = @"C:\Users\edgardo.anaya\Downloads\CodeAccelerator-main.zip";
            using (var client = new WebClient())
            {
                client.DownloadFile(url, destinationPath);
            }
        }

        public async Task DownloadZipFileWithToken(string url, string destinationPath, string token)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                {
                    await contentStream.CopyToAsync(
                        new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true));
                }
            }
        }

    }
}
