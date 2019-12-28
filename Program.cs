using System;
using System.Collections.Generic;

namespace classes_tutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var accounts = new List<BankAccount>();
            
            BankAccount account = new BankAccount("raja", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with initial balance {account.Balance}.");

            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            Console.WriteLine($"The current balance: {account.Balance}");
            account.MakeDeposit(200, DateTime.Now, "mom gave it.");
            Console.WriteLine($"The current balance: {account.Balance}");

            Console.WriteLine(account.GetAccountHistory());

            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught while creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }
        }
    }
}
