using AccountExceptionHandle.BusinessLayer;
using AccountExceptionHandle.Entity;
using AccountExceptionHandle.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankAppUnitTest
{
    [TestClass]
    public class AccountManagerTest
    {
        AccountManager target = null;
        Account acc = null;

        [TestInitialize]
        public void Init()
        {
            target = new AccountManager();
            
        }

        [TestCleanup]
        public void ClearIt()
        {
            target = null;
            acc = null;
        }


        [TestMethod]
        public void OpenAccountTest_ValidInput_ShouldUpdateBalance()
        {
            //AccountManager target = new AccountManager();
            acc = target.OpenAccount("cust1", 5000, 1234, "SAVINGS");
            
            Assert.AreEqual(5000, acc.Balance);
        }
        [TestMethod]
        public void OpenAccountTest_ValidInput_ShouldActivateAccount()
        {
            //AccountManager target = new AccountManager();
            acc = target.OpenAccount("cust2", 5000, 123, "SAVINGS");

            Assert.AreEqual(true, acc.IsActive);
        }

        [TestMethod]
        public void OpenAccountTest_ValidInput_ShouldUpdateOpenDate()
        {
            //AccountManager target = new AccountManager();
             acc = target.OpenAccount("cust3", 5000, 123, "SAVINGS");

            Assert.AreEqual(DateTime.Now, acc.OpeningDate);
        }

        [TestMethod]
        public void OpenAccountTest_ValidInputForTwoAccounts_CreateUniqueAccNum()
        {
            //AccountManager target = new AccountManager();
            acc = target.OpenAccount("cust44", 5000, 123, "SAVINGS");
            Account acc2 = target.OpenAccount("cust44", 2000, 123, "SAVINGS");

            Assert.AreNotEqual(acc.AccNo,acc2.AccNo);
        }

        //[TestMethod]
        //[ExpectedException(typeof(AccountAlreadyExistException))]
        //public void OpenAccountTest_SameNameForTwoAccounts_ThrowException()
        //{
        //    //AccountManager target = new AccountManager();
        //    acc = target.OpenAccount("cust5", 5000, 123, "SAVINGS");
        //    Account acc2 = target.OpenAccount("cust5", 2000, 123, "SAVINGS");
        //}

        [TestMethod]
        public void OpenAccountTest_SavingsAccountInput_CreateSavingsAccount()
        {
            acc = target.OpenAccount("cust6", 2000, 123, "SAVINGS");
            Assert.IsTrue(acc is Savings);
        }

        [TestMethod]
        public void OpenAccountTest_CorporateAccountInput_CreateCorporateAccount()
        {
            acc = target.OpenAccount("cust7", 2000, 123, "CORPORATE");
            // Assert.IsTrue(acc is CorporateAccount);
            Assert.IsInstanceOfType(acc, typeof(CorporateAccount));
        }

        [TestMethod]
        //[ExpectedException(typeof())]
        public void OpenAccountTest_InvalidInput_ShouldNotCreateAccount()
        {
            acc = target.OpenAccount("cust8", 2000, 123, "");
            Assert.IsNull(acc);
        }

        [TestMethod]        
        public void CloseAccountTest_ValidInput_ShouldCloseAccount()
        {
            acc = target.OpenAccount("cust8", 0, 123, "SAVINGS");
            //acc.IsActive = false;
            target.CloseAccount(acc);
            Assert.AreEqual(false,acc.IsActive);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void CloseAccountTest_ValidInput2_ShouldCloseAccount()
        {
            acc = target.OpenAccount("cust7", 0, 123, "SAVINGS");
            acc.IsActive = false;
            target.CloseAccount(acc);
            //Assert.AreEqual(false, acc.IsActive);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void CloseAccountTest_ValidInput3_ShouldCloseAccount()
        {
            target.CloseAccount(acc);
            //Assert.IsNull(acc);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountHasBalanceException))]
        public void CloseAccountTest_WithBalance_ShouldThrowException()
        {
            acc = target.OpenAccount("cust6", 10000, 123, "SAVINGS");
            //acc.IsActive = false;
            target.CloseAccount(acc);
            //Assert.AreEqual(false, acc.IsActive);
        }

        [TestMethod]
        public void CloseAccountTest_ValidInput5_ShouldCloseAccount()
        {
            acc = target.OpenAccount("cust5", 0, 123, "SAVINGS");
            target.CloseAccount(acc);
            Assert.AreEqual(DateTime.Now,acc.ClosingDate);
        }
        [TestMethod]
        public void WithdrawTest_ValidInput_ShouldDecreaseBalance()
        {
            acc = target.OpenAccount("newcust", 3000, 1234, "CORPORATE");
            acc = target.Withdraw(acc, 2000, 1234);
            Assert.AreEqual(acc.Balance,1000);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void WithdrawTest_ValidInput2_ShouldDecreaseBalance()
        {
            acc = target.OpenAccount("newcust1", 3000, 1234, "SAVINGS");
            acc = target.Withdraw(acc, 3000, 12345);
            //Assert.AreEqual(acc.Balance, 1000);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void WithdrawTest_ValidInput3_ShouldDecreaseBalance()
        {
            acc = target.OpenAccount("newcust1", 3000, 1234, "SAVINGS");
            acc.IsActive = false;
            acc = target.Withdraw(acc, 3000, 1234);
            //Assert.AreEqual(acc.Balance, 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountHasBalanceException))]
        public void WithdrawTest_ValidInput4_ShouldDecreaseBalance()
        {
            acc = target.OpenAccount("newcust2", 3000, 1234, "SAVINGS");
            
            acc = target.Withdraw(acc, 5000, 1234);
            
        }

        [TestMethod]
        public void TransferTest_ValidInput_ShouldTransferAmount()
        {
            acc = target.OpenAccount("sender1", 30000, 1234, "SAVINGS");
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "SAVINGS");

            target.Transfer(acc, acc2, 3000, 1234);
        }

        [TestMethod]
        public void TransferTest_ValidInputDiiferentTypes_ShouldTransferAmount()
        {
            acc = target.OpenAccount("sender1", 30000, 1234, "SAVINGS");
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "CORPORATE");

            target.Transfer(acc, acc2, 3000, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void TransferTest_SenderAccountInactive_ShouldNotTransferAmount()
        {
            acc = target.OpenAccount("sender1", 30000, 1234, "SAVINGS");
            acc.IsActive = false;
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "SAVINGS");

            target.Transfer(acc, acc2, 3000, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotActiveException))]
        public void TransferTest_ReceiverAccountInactive_ShouldNotTransferAmount()
        {
            acc = target.OpenAccount("sender1", 30000, 1234, "SAVINGS");            
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "SAVINGS");
            acc2.IsActive = false;

            target.Transfer(acc, acc2, 3000, 1234);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountHasBalanceException))]
        public void TransferTest_SenderAccountLowBalance_ShouldNotTransferAmount()
        {
            acc = target.OpenAccount("sender1", 300, 1234, "SAVINGS");
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "SAVINGS");
            //acc2.IsActive = false;

            target.Transfer(acc, acc2, 3000, 1234);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountAlreadyClosedException))]
        public void TransferTest_SenderAccountPinMismatch_ShouldNotTransferAmount()
        {
            acc = target.OpenAccount("sender1", 30000, 1234, "SAVINGS");
            Account acc2 = target.OpenAccount("receiver1", 2000, 123, "SAVINGS");
            //acc2.IsActive = false;

            target.Transfer(acc, acc2, 3000, 123);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotOpenedException))]
        public void DepositTest_AccountNull_ShouldNotDepositAmount()
        {
            //acc = target.OpenAccount("Deosit1", 30000, 1234, "SAVINGS");
            
            target.Deposit(acc,3000);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountNotOpenedException))]
        public void DepositTest_AccountNotActive_ShouldNotDepositAmount()
        {
            acc = target.OpenAccount("Deosit1", 30000, 1234, "SAVINGS");
            acc.IsActive = false;
            target.Deposit(acc, 3000);
        }
        [TestMethod]
        public void DepositTest_ValidInput_ShouldDepositAmount()
        {
            acc = target.OpenAccount("Deosit1", 30000, 1234, "SAVINGS");           
            target.Deposit(acc, 3000);
            //Assert.AreEqual(33000, acc.Balance);
            Assert.IsTrue(acc.IsActive);
        }
    }
}
