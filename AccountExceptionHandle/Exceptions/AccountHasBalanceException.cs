using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class AccountHasBalanceException : ApplicationException
    {
        public AccountHasBalanceException(string msg=null, Exception innerException = null)
        {

        }
    }
}
