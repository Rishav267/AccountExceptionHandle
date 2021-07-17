using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class AccountNotActiveException : ApplicationException
    {
        public AccountNotActiveException(string msg = null, Exception innerException = null)
        {

        }
    }
}
