namespace PZ_18
{
    enum TypeOfAccount { Credit, Debit }
    internal class BankAccount
    {
        decimal _accountBalance;
        ulong _accountNumber;
        public static int countOfDebitAccounts;
        public static int countOfCreditAccounts;
        TypeOfAccount _type;

        public ulong AccountNumber

        {
            get => _accountNumber;

            set
            {
                if (value > 99999 && value < 1000000)
                    _accountNumber = value;
                else
                    Console.WriteLine("Вы некорректно ввели номер счёта, он должен содержать 6 цифр\n" +
                            "Введите номер счета еще раз:");
            }
        }
        public TypeOfAccount Type
        {
            get => _type;

            set
            {
                _type = value;
            }
        }

        public BankAccount(uint accountNumber, TypeOfAccount type)
        {
            AccountNumber = accountNumber;
            Type = type;

            if (type == TypeOfAccount.Debit)
                countOfDebitAccounts++;
            if (type == TypeOfAccount.Credit)
                countOfCreditAccounts++;

            _accountBalance = Decimal.Zero;
        }

        public void Refill(decimal refillAccountBalance)
        {
            if (refillAccountBalance >= 1000)
            {
                _accountBalance += refillAccountBalance;
                Console.WriteLine($"Счет {_accountNumber} пополнен на сумму {refillAccountBalance}. Баланс: {_accountBalance}");
            }
            else
            {
                Console.WriteLine("Ошибка!!! Минимальная сумма пополнения: 1000");
            }
        }

        public void Withdrawal(decimal withdrawalAccountBalance)
        {
            if (_type == TypeOfAccount.Credit)
            {
                _accountBalance -= withdrawalAccountBalance;
                Console.WriteLine($"Счет {_accountNumber} снятие суммы {withdrawalAccountBalance}. Баланс: {_accountBalance}");
            }
            else if (_accountBalance > withdrawalAccountBalance)
            {
                _accountBalance -= withdrawalAccountBalance;
                Console.WriteLine($"Счет {_accountNumber} снятие суммы {withdrawalAccountBalance}. Баланс: {_accountBalance}");
            }
            else
                Console.WriteLine("Сумма для снятия больше, чем сумма средств на счету! Снятие невозможно :(");
        }

        public static void NumberOfAccounts()
        {
            Console.WriteLine($"Количество дебетовых счетов: {countOfDebitAccounts}\n" +
                $"Количество кредитных счетов: {countOfCreditAccounts}");
        }

    }
}
