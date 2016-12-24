using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.DataContract
{
    public class FileDto
    {
        public string Path { get; set; }

        public string Name { get; set; }

        public long Size { get; set; }

        public string Modify { get; set; }

        public string Create { get; set; }

        public string Extension { get; set; }
    }
}
