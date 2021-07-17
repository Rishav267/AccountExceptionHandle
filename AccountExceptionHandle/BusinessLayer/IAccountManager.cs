using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountExceptionHandle.Entity;

namespace AccountExceptionHandle.BusinessLayer
{
    public interface IAccountManager
    {
        Account OpenAccount(string name, double amount, int pin, string AccType);

        Account CloseAccount(Account accountToClose);

        Account Withdraw(Account account, double amount, int pin);

        Account Deposit(Account account, double amount);

        bool Transfer(Account fromAccount, Account toAccount, double amount, int pin);



    }
}
