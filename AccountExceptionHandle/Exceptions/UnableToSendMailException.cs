using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class UnableToSendMailException : ApplicationException
    {
        public UnableToSendMailException(string message=null, Exception innerException = null) : base(message,innerException)
        {

        }
    }
}
