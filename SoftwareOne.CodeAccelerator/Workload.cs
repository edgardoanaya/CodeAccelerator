namespace SoftwareOne.CodeAccelerator
{
    public class Workload
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public string AppName { get; set; }

        public string AppCompany { get; set; }

        public string GenerationFolder { get; set;} =string.Empty;

        public string TemplateFolder { get; set; } = string.Empty; 

        public string EntitiesFolder { get; set; } = string.Empty;

        public string Namespace { get; set; } = string.Empty;

        public Workload(string name)
        {
            Name = name;
        }

        public Workload(string name, string type, string appName, string appCompany, string generationFolder, string templateFolder, string entitiesFolder)
        {
            Name = name;
            Type = type;
            AppName = appName;
            AppCompany = appCompany;
            GenerationFolder = generationFolder;
            TemplateFolder = templateFolder;
            EntitiesFolder = entitiesFolder;
            Namespace = string.Concat(appCompany, "." , appName);
        }
    }
}
