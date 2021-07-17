using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountExceptionHandle.Exceptions
{
    public class AccountAlreadyExistException : ApplicationException
    {
        public AccountAlreadyExistException(string msg = null, Exception inner = null) : base(msg, inner)
        {

        }
        //public AccountAlreadyExistException()
        //{

        //}
        //public AccountAlreadyExistException(string msg) : base(msg)
        //{

        //}
    }
}
