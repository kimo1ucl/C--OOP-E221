using System;
using System.Collections.Generic;
using System.Transactions;

namespace Classes
{
    public class BankAccount
    {
        public string Number { get; }
        public Client Owner { get; set; }
        public decimal Balance
        {
            get
            {
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }

                return balance;
            }
        }

        private static int accountNumberSeed = 1234567890;
        #region Constructor
        public BankAccount(Client client, decimal initialBalance)
        {
            Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            Owner = client;
            MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }
        #endregion

        #region TransactionDeclaration
        private List<Transaction> allTransactions = new List<Transaction>();
        #endregion

        #region DepositAndWithdrawal
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }
        #endregion

        #region History
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
        #endregion
    }
}

