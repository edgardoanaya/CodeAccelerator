using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Engine
{
    public class Folder : File
    {
        public Folder(string name, string filePath)
                      : base(name, filePath)
        {
            
        }

        public Folder(string name, string elementsReplicate, string filePath)
                       : base(name, elementsReplicate, filePath)
        {
            
        }
    }
}

