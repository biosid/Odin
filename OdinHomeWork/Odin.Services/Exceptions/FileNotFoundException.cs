using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.Services.Exceptions
{
    public class FileNotFoundException : BusinessLogicException
    {
        public FileNotFoundException(string message, params object[] args)
           : base(string.Format(message, args))
        {

        }

        public FileNotFoundException(string message)
            : base(message)
        {

        }

        public FileNotFoundException()
            : base()
        {

        }

        public FileNotFoundException(string message, Exception ex)
            : base(message, ex)
        {

        }

        public FileNotFoundException(Exception ex, string message, params object[] args)
            : base(string.Format(message, args), ex)
        {

        }
    }
}
