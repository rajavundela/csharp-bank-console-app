using System;
using System.Collections.Generic;
// Classes, Properties, Methods names are Capitalized
// all variables instance, local and static  are camel case
namespace classes_tutorial{
    public class BankAccount{
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get{
                decimal balance = 0;
                foreach(var item in allTransactions){
                    balance += item.Amount;
                }
                return balance;
            }
        }
        private static int accountNumberSeed = 1234567890;
        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance){
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();accountNumberSeed++;
        }
        
        public void MakeDeposit(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            allTransactions.Add(new Transaction(amount, date, note));
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0){
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            allTransactions.Add(new Transaction(-amount, date, note));
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal balance = 0;
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }
    }
}