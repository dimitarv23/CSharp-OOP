using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] bankAccountsInfo = Console.ReadLine().Split(',');
            List<BankAccount> accounts = new List<BankAccount>();

            foreach (var bankAccInfo in bankAccountsInfo)
            {
                string[] currBankAcc = bankAccInfo.Split('-');

                BankAccount account = new BankAccount(int.Parse(currBankAcc[0]), double.Parse(currBankAcc[1]));
                accounts.Add(account);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] cmdArgs = command.Split();
                string action = cmdArgs[0];

                try
                {
                    int accountNumber = int.Parse(cmdArgs[1]);
                    double sum = double.Parse(cmdArgs[2]);

                    if (!accounts.Any(a => a.AccountNumber == accountNumber))
                    {
                        throw new Exception("Invalid account!");
                    }

                    var acc = accounts.First(a => a.AccountNumber == accountNumber);

                    if (action == "Deposit")
                    {
                        acc.Deposit(sum);
                    }
                    else if (action == "Withdraw")
                    {
                        if (acc.Balance < sum)
                        {
                            throw new Exception("Insufficient balance!");
                        }

                        acc.Withdraw(sum);
                    }
                    else
                    {
                        throw new Exception("Invalid command!");
                    }

                    Console.WriteLine($"Account {acc.AccountNumber} has new balance: {acc.Balance:f2}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                command = Console.ReadLine();
            }
        }
    }

    public class BankAccount
    {
        private int accountNumber;
        private double balance;

        public BankAccount(int accountNumber, double balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (true)
                {

                }

                accountNumber = value;
            }
        }
        public double Balance
        {
            get { return balance; }
            set
            {
                if (true)
                {

                }

                balance = value;
            }
        }

        public void Deposit(double sum)
        {
            this.Balance += sum;
        }

        public void Withdraw(double sum)
        {
            this.Balance -= sum;
        }
    }
}
