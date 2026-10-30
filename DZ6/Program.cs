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
        private static int nextAccountNumber = 1000000;

        private string accountNumber;
        private decimal balance;
        private AccountType type;

        public BankAccount(decimal initialBalance, AccountType accountType)
        {
            accountNumber = GenerateAccountNumber();
            balance = initialBalance;
            type = accountType;
        }

        private static string GenerateAccountNumber()
        {
            nextAccountNumber++;
            return nextAccountNumber.ToString();
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
            Console.Write("Введите баланс: ");
            decimal balance1 = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Выберите тип счета:");
            Console.WriteLine("1 - Текущий");
            Console.WriteLine("2 - Сберегательный");
            Console.WriteLine("3 - Депозитный");
            Console.Write("Ваш выбор: ");
            int choice1 = int.Parse(Console.ReadLine());

            AccountType type1;
            switch (choice1)
            {
                case 1: type1 = AccountType.Current; break;
                case 2: type1 = AccountType.Savings; break;
                case 3: type1 = AccountType.Deposit; break;
                default: type1 = AccountType.Current; break;
            }

            BankAccount account1 = new BankAccount(balance1, type1);
            Console.WriteLine();
            account1.PrintInfo();

            Console.WriteLine();

            Console.Write("Введите баланс: ");
            decimal balance2 = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Выберите тип счета:");
            Console.WriteLine("1 - Текущий");
            Console.WriteLine("2 - Сберегательный");
            Console.WriteLine("3 - Депозитный");
            Console.Write("Ваш выбор: ");
            int choice2 = int.Parse(Console.ReadLine());

            AccountType type2;
            switch (choice2)
            {
                case 1: type2 = AccountType.Current; break;
                case 2: type2 = AccountType.Savings; break;
                case 3: type2 = AccountType.Deposit; break;
                default: type2 = AccountType.Current; break;
            }

            BankAccount account2 = new BankAccount(balance2, type2);
            Console.WriteLine();
            account2.PrintInfo();

            Console.ReadKey();
        }
    }
}