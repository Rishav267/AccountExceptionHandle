using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class AccountNotOpenedException : ApplicationException
    {
        public AccountNotOpenedException(string msg=null, Exception innerException = null) : base(msg,innerException)
        {

        }
    }
}
