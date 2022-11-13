using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Hans", "Jensen", "Paradisæblevej 111");
            //use the new client in the creation of a bankaccount
            BankAccount account = new BankAccount(client, 1000);

            //Pull out the client from bankaccount to see if that the data matches
            Client testclient = account.Owner;
            string output = String.Format(
                "Account {0} was created for {1} {2} with {3} balance.",
                account.Number,
                testclient.FirstName,
                testclient.LastName,
                account.Balance
                );
            Console.WriteLine(output);
            Console.ReadLine();

            //BankAccount account = new BankAccount("Hans", 1000);
            //Console.WriteLine($"Account {account.Number} was created" +
            //    " for {account.Owner} with {account.Balance} balance.");






            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            //Console.WriteLine(account.Balance);
            //account.MakeDeposit(100, DateTime.Now, "friend paid me back");
            //Console.WriteLine(account.Balance);

            //Console.WriteLine(account.GetAccountHistory());

            //// Test that the initial balances must be positive:
            //try
            //{
            //    var invalidAccount = new BankAccount("invalid", -55);
            //}
            //catch (ArgumentOutOfRangeException e)
            //{
            //    Console.WriteLine("Exception caught creating account with negative balance");
            //    Console.WriteLine(e.ToString());
            //}

            //// Test for a negative balance
            //try
            //{
            //    account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            //}
            //catch (InvalidOperationException e)
            //{
            //    Console.WriteLine("Exception caught trying to overdraw");
            //    Console.WriteLine(e.ToString());
            //}
        }

    }
}
