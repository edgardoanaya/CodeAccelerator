using System.Collections.Generic;

namespace SoftwareOne.CodeAccelerator
{
    public class RulesGenerator
    {
        string Workload { get; set; }

        public List<Template> Rules { get; set; }

        public RulesGenerator(string workload)
        {
            this.Workload = workload;
            Rules = new List<Template>();
        }

        public List<Template> GetRules()
        {
            if (Workload.Contains("Backend_Net_7"))
            {
                CodeBlock codeEntity;

                // SoftwareOne.BaseLine.Entities
                File file = new File("City_Template.cs", "SoftwareOne.BaseLine.Entities\\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                CodeBlock codeField = new CodeBlock("Campos", file.ContentReplace
                    , "\r\n        /// <summary>\r\n        /// Property to manage the Operation field\r\n        /// </summary>\r\n        //{DecoratorField}\r\n        public string Operation { get; set; } //{DefaultField}"
                    , "Field");
                codeField.AddElement(new Variable("string", codeField.ContentReplace, "{Field.Type}"));
                codeField.AddElement(new Variable("Operation", codeField.ContentReplace, "{Field.Name}"));
                codeField.AddElement(new Tag("//{DefaultField}", codeField.ContentReplace, "{Field.Default}"));
                codeField.AddElement(new Tag("//{DecoratorField}", codeField.ContentReplace, "{Field.ForeignKey}"));
                file.AddElement(codeField);
                Rules.Add(file);

                // SoftwareOne.BaseLine.Entities\Extended  ????????
                //file = new File("IAudit.cs", "SoftwareOne.BaseLine.Entities\\Audit_test.cs", "Entity");
                //file.AddElement(new Variable("Audit_test", file.ContentReplace, "{Entity.Name}"));
                //file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));

                // SoftwareOne.BaseLine.EntitiesDto
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.EntitiesDto\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                codeField = new CodeBlock("Campos", file.ContentReplace
                    , "\r\n        /// <summary>\r\n        /// Property to manage the Name field\r\n        /// </summary>\r\n        public string Name { get; set; } //{DefaultField}"
                    , "Field");
                codeField.AddElement(new Variable("string", codeField.ContentReplace, "{Field.Type}"));
                codeField.AddElement(new Variable("Name", codeField.ContentReplace, "{Field.Name}"));
                codeField.AddElement(new Tag("//{DefaultField}", codeField.ContentReplace, "{Field.Default}"));
                file.AddElement(codeField);
                Rules.Add(file);

                // SoftwareOne.BaseLine.Interfaces\DataAccess
                file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\DataAccess\ICity_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.Interfaces\ApplicationServices\Facade
                file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\ApplicationServices\Facade\ICity_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.Interfaces\ApplicationServices\Services
                file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\ApplicationServices\Services\ICity_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.DataAccess.SqlServer
                // todo: Revisar esta diferente clase Product y ShoppingCart de la linea base
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.DataAccess.SqlServer\Common\Configurations
                file = new File("CityConfiguration.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\Common\Configurations\CityConfiguration.cs", "Entity");
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                codeField = new CodeBlock("Campos", file.ContentReplace, "//{MaxLengthField}", "Field");
                codeField.AddElement(new Tag("//{MaxLengthField}", codeField.ContentReplace, "{Field.MaxLength}"));
                file.AddElement(codeField);
                Rules.Add(file);

                // SoftwareOne.BaseLine.DataAccess.SqlServer\Common
                file = new File("MainContextApplication.SetEntities.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\Common\MainContextApplication.SetEntities.cs");
                codeEntity = new CodeBlock("//{DbSet.Entities.City}"
                    , "public virtual DbSet<Entities.City>? City { get; set; }\r\n        "
                    , "public virtual DbSet<Entities.City>? City { get; set; }"
                    , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                file.AddElement(codeEntity);
                Rules.Add(file);

                // SoftwareOne.BaseLine.ApplicationServices\Facade
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Facade\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.ApplicationServices\Facade\Extended
                // pendiente: .ForMember(dest => dest.Categories, act => act.Ignore())
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Facade\Extended\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                codeField = new CodeBlock("Campos", file.ContentReplace, "//{MapperFacadeForeignKey}", "Field");
                codeField.AddElement(new Tag("//{MapperFacadeForeignKey}", codeField.ContentReplace, "{Field.ForeignKey}"));
                file.AddElement(codeField);
                Rules.Add(file);

                // SoftwareOne.BaseLine.ApplicationServices\Services
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Services\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.ApplicationServices\Validators
                file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Validators\City_Template.cs", "Entity");
                file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                codeField = new CodeBlock("Campos", file.ContentReplace, "//{ValidatorsIsRequiredField}\r\n            //{ValidatorsMaxLengthField}\r\n            //{ValidatorsPrecisionField}", "Field");
                codeField.AddElement(new Tag("//{ValidatorsIsRequiredField}", codeField.ContentReplace, "{Field.IsRequired}"));
                codeField.AddElement(new Tag("//{ValidatorsMaxLengthField}", codeField.ContentReplace, "{Field.MaxLength}"));
                codeField.AddElement(new Tag("//{ValidatorsPrecisionField}", codeField.ContentReplace, "{Field.Precision}"));
                file.AddElement(codeField);
                Rules.Add(file);

                // SoftwareOne.BaseLine.Api\Controllers\v1
                file = new File("CityController.cs", @"SoftwareOne.BaseLine.Api\Controllers\v1\CityController.cs", "Entity");
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.Api\Controllers\v1\Extended
                file = new File("CityController.cs", @"SoftwareOne.BaseLine.Api\Controllers\v1\Extended\CityController.cs", "Entity");
                file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
                file.AddElement(new Variable("Operation", file.ContentReplace, "{Entity.OrderDefault}"));
                Rules.Add(file);

                // SoftwareOne.BaseLine.Api
                file = new File("Program.cs", @"SoftwareOne.BaseLine.Api\Program.cs");
                codeEntity = new CodeBlock("//{Interfaces.DataAccess.ICity}"
                    , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.ICity, SoftwareOne.BaseLine.DataAccess.SqlServer.City>();\r\n    "
                    , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.DataAccess.ICity, SoftwareOne.BaseLine.DataAccess.SqlServer.City>();"
                    , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                file.AddElement(codeEntity);

                codeEntity = new CodeBlock("//{Interfaces.ApplicationServices.Services}"
                    , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.ICity, SoftwareOne.BaseLine.ApplicationServices.Services.City>();\r\n    "
                    , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Services.ICity, SoftwareOne.BaseLine.ApplicationServices.Services.City>();"
                    , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                file.AddElement(codeEntity);

                codeEntity = new CodeBlock("//{Interfaces.ApplicationServices.Facade}"
                   , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.ICity, SoftwareOne.BaseLine.ApplicationServices.Facade.City>();\r\n    "
                   , "builder.Services.AddTransient<SoftwareOne.BaseLine.Interfaces.ApplicationServices.Facade.ICity, SoftwareOne.BaseLine.ApplicationServices.Facade.City>();"
                   , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                file.AddElement(codeEntity);

                codeEntity = new CodeBlock("//{Services.AddSingleton}"
                  , "builder.Services.AddSingleton<City>();\r\n    "
                  , "builder.Services.AddSingleton<City>();"
                  , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                file.AddElement(codeEntity);
                Rules.Add(file);

                // SoftwareOne.BaseLine.TestAPI
                file = new File("BackEnd.postman_Template.json", @"SoftwareOne.BaseLine.TestAPI\BackEnd.postman_Template.json");
                codeEntity = new CodeBlock("{Entity}"
                    , ",\t\t\r\n\t\t{\r\n\t\t\t\"name\": \"City\",\r\n\t\t\t\"item\": [\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Create\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"POST\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"body\": {\r\n\t\t\t\t\t\t\t\"mode\": \"raw\",\r\n\t\t\t\t\t\t\t\"raw\": \"{ApiPostmanCreateField}\",\r\n\t\t\t\t\t\t\t\"options\": {\r\n\t\t\t\t\t\t\t\t\"raw\": {\r\n\t\t\t\t\t\t\t\t\t\"language\": \"json\"\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"List\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"GET\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/GetPage\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"GetPage\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"GetById\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"GET\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/6\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"6\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Update\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"PUT\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"body\": {\r\n\t\t\t\t\t\t\t\"mode\": \"raw\",\r\n\t\t\t\t\t\t\t\"raw\": \"{ApiPostmanUpdateField}\",\r\n\t\t\t\t\t\t\t\"options\": {\r\n\t\t\t\t\t\t\t\t\"raw\": {\r\n\t\t\t\t\t\t\t\t\t\"language\": \"json\"\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Delete\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"DELETE\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/6\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"6\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t}\r\n\t\t\t]\r\n\t\t}"
                    , ",\t\t\r\n\t\t{\r\n\t\t\t\"name\": \"City\",\r\n\t\t\t\"item\": [\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Create\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"POST\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"body\": {\r\n\t\t\t\t\t\t\t\"mode\": \"raw\",\r\n\t\t\t\t\t\t\t\"raw\": \"{ApiPostmanCreateField}\",\r\n\t\t\t\t\t\t\t\"options\": {\r\n\t\t\t\t\t\t\t\t\"raw\": {\r\n\t\t\t\t\t\t\t\t\t\"language\": \"json\"\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"List\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"GET\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/GetPage\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"GetPage\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"GetById\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"GET\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/6\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"6\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Update\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"PUT\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"body\": {\r\n\t\t\t\t\t\t\t\"mode\": \"raw\",\r\n\t\t\t\t\t\t\t\"raw\": \"{ApiPostmanUpdateField}\",\r\n\t\t\t\t\t\t\t\"options\": {\r\n\t\t\t\t\t\t\t\t\"raw\": {\r\n\t\t\t\t\t\t\t\t\t\"language\": \"json\"\r\n\t\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t},\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t},\r\n\t\t\t\t{\r\n\t\t\t\t\t\"name\": \"Delete\",\r\n\t\t\t\t\t\"request\": {\r\n\t\t\t\t\t\t\"method\": \"DELETE\",\r\n\t\t\t\t\t\t\"header\": [\r\n\t\t\t\t\t\t\t{\r\n\t\t\t\t\t\t\t\t\"key\": \"Authorization\",\r\n\t\t\t\t\t\t\t\t\"value\": \"{{token}}\",\r\n\t\t\t\t\t\t\t\t\"type\": \"text\"\r\n\t\t\t\t\t\t\t}\r\n\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\"url\": {\r\n\t\t\t\t\t\t\t\"raw\": \"{{host}}/api/v1/City/6\",\r\n\t\t\t\t\t\t\t\"host\": [\r\n\t\t\t\t\t\t\t\t\"{{host}}\"\r\n\t\t\t\t\t\t\t],\r\n\t\t\t\t\t\t\t\"path\": [\r\n\t\t\t\t\t\t\t\t\"api\",\r\n\t\t\t\t\t\t\t\t\"v1\",\r\n\t\t\t\t\t\t\t\t\"City\",\r\n\t\t\t\t\t\t\t\t\"6\"\r\n\t\t\t\t\t\t\t]\r\n\t\t\t\t\t\t}\r\n\t\t\t\t\t},\r\n\t\t\t\t\t\"response\": []\r\n\t\t\t\t}\r\n\t\t\t]\r\n\t\t}"
                    , "Entity");
                codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
                codeEntity.AddElement(new Tag("{ApiPostmanCreateField}", codeEntity.ContentReplace, "{Field.Name}"));
                codeEntity.AddElement(new Tag("{ApiPostmanUpdateField}", codeEntity.ContentReplace, "{Field.Name}"));
                file.AddElement(codeEntity);
                Rules.Add(file);

                // change namespace in .cs
                Folder folder = new Folder("Folder", @"", "*.cs");
                folder.AddElement(new Variable("SoftwareOne.BaseLine", folder.ContentReplace, "namespace"));
                Rules.Add(folder);

                // change namespace .csproj
                folder = new Folder("Folder", @"", "*.csproj");
                folder.AddElement(new Variable("SoftwareOne.BaseLine", folder.ContentReplace, "namespace"));
                Rules.Add(folder);

                // change namespace .sln
                folder = new Folder("Folder", @"", "*.sln");
                folder.AddElement(new Variable("SoftwareOne.BaseLine", folder.ContentReplace, "namespace"));
                Rules.Add(folder);

                folder = new Folder("Folder", "", "*", true);
                folder.AddElement(new Variable("SoftwareOne.BaseLine", folder.ContentReplace, "namespace"));
                Rules.Add(folder);


                //write the string generator to a file json
                //string json = JsonSerializer.Serialize(generator);
                //System.IO.File.WriteAllText(@"C:\SWO\Demo\generatorBackend.json", json);
            }
            return Rules;
        }
    }
}
