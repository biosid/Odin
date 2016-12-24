using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odin.Services.Exceptions
{
    public class BusinessLogicException : Exception
    {
        public BusinessLogicException(string message, params object[] args)
           : base(string.Format(message, args))
        {

        }

        public BusinessLogicException(string message)
            : base(message)
        {

        }

        public BusinessLogicException()
            : base()
        {

        }

        public BusinessLogicException(string message, Exception ex)
            : base(message, ex)
        {

        }

        public BusinessLogicException(Exception ex, string message, params object[] args)
            : base(string.Format(message, args), ex)
        {

        }
    }
}
