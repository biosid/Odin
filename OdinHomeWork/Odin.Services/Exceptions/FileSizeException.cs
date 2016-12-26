using System;

namespace Odin.Services.Exceptions
{
    public class FileSizeException : BusinessLogicException
    {
        public FileSizeException(string message, params object[] args)
           : base(string.Format(message, args))
        {

        }

        public FileSizeException(string message)
            : base(message)
        {

        }

        public FileSizeException()
            : base()
        {

        }

        public FileSizeException(string message, Exception ex)
            : base(message, ex)
        {

        }

        public FileSizeException(Exception ex, string message, params object[] args)
            : base(string.Format(message, args), ex)
        {

        }
    }
}
