using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using AccountExceptionHandle.Entity;
using AccountExceptionHandle.Exceptions;

namespace AccountExceptionHandle.BusinessLayer
{
    public class AccountManager : IAccountManager
    {
        //opening, closing, withdraw, deposits and transfer
        private static int counter = 1000;
        public static Dictionary<string, Account> accounts { get; set; } = new Dictionary<string, Account>();


        public Account CloseAccount(Account accountToClose)
        {
            if(accountToClose == null || !accountToClose.IsActive)
            {
                throw new AccountAlreadyClosedException("Account already closed or does not exist");
            }
            if(accountToClose.Balance >0)
            {
                throw new AccountHasBalanceException("Account has balance, can not close ");
            }

            accountToClose.IsActive = false;
            accountToClose.ClosingDate = DateTime.Now;
            //accounts.Remove(accountToClose.Name);
            return accountToClose;            
        }

        public Account Deposit(Account account , double amount)
        {
            if(account == null)
            {
                throw new AccountNotOpenedException("Account does not exist, open new account");
            }
            if(!account.IsActive)
            {
                throw new AccountNotOpenedException("Account does not exist, open new account");
            }
            

            account.Balance += amount;
            return account;
                        
        }

        public Account OpenAccount(string name, double amount, int pin, string AccType)
        {
            Account account = null;
            //accounts.Remove(name);
            //if(accounts.ContainsKey(name))
            //{                
            //    throw new AccountAlreadyExistException("Account already exist");
            //}            

            switch (AccType)
            {
                case "SAVINGS":
                    account = new Savings();                    
                    break;
                case "CORPORATE":
                    account = new CorporateAccount();
                    break;
                default:
                    return null;
            }
            account.AccNo = counter++;
            account.Balance = amount;
            account.Pin = pin;
            account.Name = name;
            account.OpeningDate = DateTime.Now;
            account.IsActive = true;
            //accounts.Add(name, account);
            //try
            //{
            //    NotificationService notificationService = new NotificationService();
            //    notificationService.SendMail($"{name}@gmail.com", "Account successfully created", "Account opened");
                
            //}
            //catch (UnableToSendMailException ex)
            //{
            //    Console.WriteLine(ex.Message); //"Failure in sending mail");
            //    throw;
            //}
            return account;
        }

        public bool Transfer(Account fromAccount, Account toAccount, double amount , int pin )
        {
            if(!fromAccount.IsActive )
            {
                throw new AccountNotActiveException("Sender account might be inactive, kindly check");
            }
            else if(!toAccount.IsActive)
            {
                throw new AccountNotActiveException("Receiver account might be inactive, kindly check");
            }
            else if(fromAccount.Balance < amount )
            {
                throw new AccountHasBalanceException("account does nit have sufficient balance");
            }
            else if(fromAccount.Pin != pin)
            {
                throw new AccountAlreadyClosedException("pin does not match");
            }
            else
            {
                fromAccount.Balance -= amount;
                toAccount.Balance += amount;
            }
            
            return true;
        }

        public Account Withdraw(Account account , double amount, int pin)
        {
            if (!account.IsActive)
            {
                throw new AccountAlreadyClosedException("Either account is already closed or inactive , kindly check");
            }
            else if (account.Pin != pin)
            {
                throw new AccountNotActiveException("pin does not match");
            }
            else if(account.Balance < amount)
            {
                throw new AccountHasBalanceException("Account balance lower than withdraw amount");
            }
            else
                account.Balance -= amount;

            return account;           
        }
    }
}
