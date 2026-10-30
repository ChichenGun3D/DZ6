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

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма пополнения должна быть положительной.");
                return;
            }
            balance += amount;
            Console.WriteLine($"Счет пополнен на {amount:C}. Текущий баланс: {balance:C}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Сумма снятия должна быть положительной.");
                return;
            }
            if (amount > balance)
            {
                Console.WriteLine($"Недостаточно средств. Запрошено: {amount:C}, доступно: {balance:C}");
                return;
            }
            balance -= amount;
            Console.WriteLine($"Снято со счета: {amount:C}. Текущий баланс: {balance:C}");
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
            Console.Write("Введите начальный баланс: ");
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
            Console.Write("Введите сумму для пополнения: ");
            decimal depositAmount = decimal.Parse(Console.ReadLine());
            account1.Deposit(depositAmount);

            Console.WriteLine();
            Console.Write("Введите сумму для снятия: ");
            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
            account1.Withdraw(withdrawAmount);

            Console.WriteLine();
            account1.PrintInfo();

            Console.ReadKey();
        }
    }
}