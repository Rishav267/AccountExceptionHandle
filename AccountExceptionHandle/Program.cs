using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccountExceptionHandle.BusinessLayer;
using AccountExceptionHandle.Entity;

namespace AccountExceptionHandle
{
    class Program
    {
        static void Main(string[] args)
        {

            //create a menu driven system
            AccountManager accountManager = new AccountManager();
            Account account = null ;

            while (true)
            {
                Console.WriteLine("Enter the facility you want to avail : 1) Create an Account 2) Check Balance 3) Make a deposit 4) Make a Withdrawal" +
                    "5) Transfer 6) Close Account 7) Exit");

                int choice = int.Parse(Console.ReadLine());


                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Enter the Account Holder Name: ");
                            string name = Console.ReadLine();

                            Console.WriteLine("Enter the amount to be deposited : ");
                            double bal = double.Parse(Console.ReadLine());

                            Console.WriteLine("Enter the account pin : ");
                            int pin = int.Parse(Console.ReadLine());

                            Console.WriteLine("Enter type of account : SAVINGS or  CURRENT");
                            string type = Console.ReadLine();

                            account = accountManager.OpenAccount(name, bal, pin, type);
                            Console.WriteLine(account.AccNo);
                            Console.WriteLine(account.Balance);
                            break;

                        case 2:
                            if (account != null && account.Balance != 0)
                                Console.WriteLine(account.Balance);
                            else
                                Console.WriteLine("Could not show balance, check your account status");
                            break;

                        case 3:
                            //Console.WriteLine("enter account number : ");
                            //int num = int.Parse(Console.ReadLine());

                            Console.WriteLine("enter the amount to be deposited : ");
                            double amount = double.Parse(Console.ReadLine());

                            //Account acc = new Account();
                            //account.AccNo = num;
                            var accountReturn = accountManager.Deposit(account, amount);
                            Console.WriteLine(accountReturn.Balance);
                            break;

                        case 4:
                            Console.WriteLine("enter account number : ");
                            int numA = int.Parse(Console.ReadLine());

                            Console.WriteLine("enter the amount to be deposited : ");
                            double amountW = double.Parse(Console.ReadLine());

                            Console.WriteLine("enter account pin : ");
                            int pinCheck = int.Parse(Console.ReadLine());


                            var a = accountManager.Withdraw(account, amountW, pinCheck);
                            Console.WriteLine(a.Balance);
                            break;

                        case 5:
                            //Console.WriteLine("enter account number of sender's account : ");
                            //int acc1 = int.Parse(Console.ReadLine());

                            Console.WriteLine("enter account number of receiver's account : ");
                            int acc2 = int.Parse(Console.ReadLine());

                            Account account2 = new Account();
                            account2.AccNo = acc2;
                            Console.WriteLine("enter amount to be transferred : ");
                            double Tamount = double.Parse(Console.ReadLine());

                            Console.WriteLine("enter pin for sender's account : ");
                            int Tpin = int.Parse(Console.ReadLine());

                            bool res = accountManager.Transfer(account, account2, Tamount, Tpin);

                            if (res == true)
                                Console.WriteLine("money successfully transferred ");
                            else
                                Console.WriteLine("money transfer failed, check account status ");
                            break;

                        case 6:
                            Console.WriteLine("enter account holder name to close account : ");
                            string Aname = Console.ReadLine();

                            account.Name = Aname;
                            accountManager.CloseAccount(account);
                            break;

                        case 7:
                            return;
                            //break;

                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("parameter value can't be empty,kindly fill relevent value");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                }
            }     
            
            //open account with same name

            //close account which is already closed

            //
        }
    }
}
