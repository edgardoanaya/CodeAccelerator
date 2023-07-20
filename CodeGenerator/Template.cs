using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Engine
{
    public interface Template
    {
        string Name { get; set; }
                
        string ContentReplicate { get; set; }

        string ContentReplace { get; set; }

        string VariableNewText { get; set; }

        
        Template Get(string name);

        string Rename();

        string Replace();

        string Replace(string contenido, object entity);

        string Replicate();

        string Replicate(List<Field> list);

        string Execute();
    }
}