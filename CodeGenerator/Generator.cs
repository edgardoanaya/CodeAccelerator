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
    }
}
