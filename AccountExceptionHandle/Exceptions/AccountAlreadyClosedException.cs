using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class AccountAlreadyClosedException : ApplicationException
    {
        public AccountAlreadyClosedException(string msg=null,Exception innerException = null)
        {

        }
    }
}
