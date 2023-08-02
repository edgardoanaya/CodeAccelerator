using System.Collections.Generic;

namespace SoftwareOne.CodeAccelerator
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