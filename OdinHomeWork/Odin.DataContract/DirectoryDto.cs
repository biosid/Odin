using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DataContract
{
    public class DirectoryDto
    {
        public string ParentPath { get; set; }

        public string Name { get { return Path.Replace(ParentPath, ""); } set { } }

        public string Path { get; set; }
    }
}
