using CodeGenerator.Engine;
using System;
using System.Windows.Forms;
using System.Text.Json;
using System.Reflection;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        private Generator generator ;
        
        
        public Form1()
        {
            InitializeComponent();
            
            
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            generator = new Generator();
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

            //CodeBlock codEntity = new CodeBlock("Entidades", file.ContentReplace
            //    , "namespace SoftwareOne.BaseLine.Entities\r\n{\r\n    /// <summary>\r\n    /// Entity to manage the City entity\r\n    /// </summary>\r\n    public partial class City : Core.Entities.IEntity\r\n    {\r\n        /// <summary>\r\n        /// Property to manage the Id field\r\n        /// </summary>\r\n        public int Id { get; set; }\r\n        /// <summary>\r\n        /// Property to manage the Entity field\r\n        /// </summary>\r\n        public string Operation { get; set; } = null!;\r\n\t\t        \r\n    }\r\n}\r\n\r\n"
            //    , "Entity");            
            //codEntity.AddElement(new Variable("City", codEntity.ContentReplace, "{Entity.Name}"));            
            //codEntity.AddElement(codeField);

            file.AddElement(codeField);
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Entities\Extended  ????????
            //file = new File("IAudit.cs", "SoftwareOne.BaseLine.Entities\\Audit_test.cs", "Entity");
            //file.AddElement(new Variable("Audit_test", file.ContentReplace, "{Entity.Name}"));
            //file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));

            //codeField = new CodeBlock("Campos", file.ContentReplace
            //    , "\r\n        /// <summary>\r\n        /// Property to manage the Entity field\r\n        /// </summary>\r\n        public string Operation { get; set; } = null!;"
            //    , "Field");
            //codeField.AddElement(new Variable("string", codeField.ContentReplace, "{Field.Type}"));
            //codeField.AddElement(new Variable("Operation", codeField.ContentReplace, "{Field.Name}"));
            //codeField.AddElement(new Variable("null!", codeField.ContentReplace, "{Field.Default}")); 
            //file.AddElement(codeField);
            //generator.Rules.Add(file);


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
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Interfaces\DataAccess
            file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\DataAccess\ICity_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Interfaces\ApplicationServices\Facade
            file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\ApplicationServices\Facade\ICity_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Interfaces\ApplicationServices\Services
            file = new File("ICity_Template.cs", @"SoftwareOne.BaseLine.Interfaces\ApplicationServices\Services\ICity_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // todo: Revisar esta diferente clase Product y ShoppingCart de la linea base
            // SoftwareOne.BaseLine.DataAccess.SqlServer
            file = new File("City_Template.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\City_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.DataAccess.SqlServer\Common\Configurations
            file = new File("CityConfiguration.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\Common\Configurations\CityConfiguration.cs", "Entity");
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            codeField = new CodeBlock("Campos", file.ContentReplace, "//{MaxLengthField}", "Field");
            codeField.AddElement(new Tag("//{MaxLengthField}", codeField.ContentReplace, "{Field.MaxLength}"));
            file.AddElement(codeField);
            generator.Rules.Add(file);

            //// SoftwareOne.BaseLine.DataAccess.SqlServer\Common
            //file = new File("MainContextApplication.SetEntities.cs", @"SoftwareOne.BaseLine.DataAccess.SqlServer\Common\MainContextApplication.SetEntities.cs", "Entity");
            //CodeBlock codeEntity = new CodeBlock("Entities", file.ContentReplace
            //    , "public virtual DbSet<Entities.City>? Citys { get; set; }", "Entity");
            //codeEntity.AddElement(new Variable("City", codeEntity.ContentReplace, "{Entity.Name}"));
            //file.AddElement(codeEntity);
            //generator.Rules.Add(file);

            // SoftwareOne.BaseLine.ApplicationServices\Facade
            file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Facade\City_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            //// SoftwareOne.BaseLine.ApplicationServices\Facade\Extended
            //file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Facade\Extended\City_Template.cs", "Entity");
            //file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            //file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            //generator.Rules.Add(file);

            // SoftwareOne.BaseLine.ApplicationServices\Services
            file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Services\City_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.ApplicationServices\Validators
            file = new File("City_Template.cs", @"SoftwareOne.BaseLine.ApplicationServices\Validators\City_Template.cs", "Entity");
            file.AddElement(new Variable("City_Template", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            codeField = new CodeBlock("Campos", file.ContentReplace, "//{ValidatorsIsRequiredField}\r\n            //{ValidatorsMaxLengthField}\r\n            //{ValidatorsPrecisionField}", "Field");
            codeField.AddElement(new Tag("//{ValidatorsIsRequiredField}", codeField.ContentReplace, "{Field.IsRequired}"));
            codeField.AddElement(new Tag("//{ValidatorsMaxLengthField}", codeField.ContentReplace, "{Field.MaxLength}"));
            codeField.AddElement(new Tag("//{ValidatorsPrecisionField}", codeField.ContentReplace, "{Field.Precision}"));
            file.AddElement(codeField);
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Api\Controllers\v1
            file = new File("CityController.cs", @"SoftwareOne.BaseLine.Api\Controllers\v1\CityController.cs", "Entity");
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            generator.Rules.Add(file);

            // SoftwareOne.BaseLine.Api\Controllers\v1\Extended
            file = new File("CityController.cs", @"SoftwareOne.BaseLine.Api\Controllers\v1\Extended\CityController.cs", "Entity");
            file.AddElement(new Variable("City", file.ContentReplace, "{Entity.Name}"));
            file.AddElement(new Variable("Operation", file.ContentReplace, "{Entity.OrderDefault}"));
            generator.Rules.Add(file);

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

            generator.Rules.Add(file);

            //write the string generator to a file json
            //string json = JsonSerializer.Serialize(generator);
            //System.IO.File.WriteAllText(@"C:\SWO\Demo\generatorBackend.json", json);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Workspace.Initialize();

            //write the string entidades to a file json
            string json = JsonSerializer.Serialize(Workspace.entities);
            System.IO.File.WriteAllText(@"C:\SWO\Demo\generatorEntities.json", json);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = generator.Rules[12].Execute();
            //textBox2.Text += motor.rules[1].Replicate();
            //textBox2.Text=motor.rules[1].Replace();
            //textBox2.Text = motor.rules[1].ContentReplace;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = generator.ExcuteRules();
        }
    }
}
