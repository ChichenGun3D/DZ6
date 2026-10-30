using System;

namespace BankAccountApp
{
    public enum AccountType
    {
        Current,
        Savings,
        Deposit
    }

    public class BankAccount
    {
        private string accountNumber;
        private decimal balance;
        private AccountType type;

        public void SetData(string number, decimal initialBalance, AccountType accountType)
        {
            accountNumber = number;
            balance = initialBalance;
            type = accountType;
        }

        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public AccountType GetAccountType()
        {
            return type;
        }

        public void PrintInfo()
        {
            Console.WriteLine("--- Информация о счете ---");
            Console.WriteLine($"Номер счета: {accountNumber}");
            Console.WriteLine($"Баланс: {balance:C}");
            Console.WriteLine($"Тип счета: {GetTypeName(type)}");
        }

        private string GetTypeName(AccountType t)
        {
            switch (t)
            {
                case AccountType.Current: return "Текущий";
                case AccountType.Savings: return "Сберегательный";
                case AccountType.Deposit: return "Депозитный";
                default: return "Неизвестно";
            }
        }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            BankAccount myAccount = new BankAccount();

            Console.Write("Введите номер счета: ");
            string number = Console.ReadLine();

            Console.Write("Введите баланс: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Выберите тип счета:");
            Console.WriteLine("1 - Текущий");
            Console.WriteLine("2 - Сберегательный");
            Console.WriteLine("3 - Депозитный");
            Console.Write("Ваш выбор: ");
            int choice = int.Parse(Console.ReadLine());

            AccountType type;
            switch (choice)
            {
                case 1: type = AccountType.Current; break;
                case 2: type = AccountType.Savings; break;
                case 3: type = AccountType.Deposit; break;
                default: type = AccountType.Current; break;
            }

            myAccount.SetData(number, balance, type);
            Console.WriteLine();
            myAccount.PrintInfo();

            Console.ReadKey();
        }
    }
}