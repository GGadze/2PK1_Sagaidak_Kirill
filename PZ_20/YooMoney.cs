using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoleProject
{
    internal class YooMoney : IWallet
    {
        public int Sum { get; set; }

        public long number;
        public string clientFIO;
        public DateTime validity;
        public int secureCode;

        public YooMoney(long number, string clientFIO, DateTime validity, int secureCode)
        {
            this.number = number;
            this.clientFIO = clientFIO;
            this.validity = validity;
            this.secureCode = secureCode;
            Sum = 0;
        }

        public void AddMoney(int sum)
        {
            Sum += sum;
        }

        public int DecMoney(int sum)
        {
            if (sum > Sum)
            {
                Console.WriteLine("Не хватает денежек для сняти :(");
                return Sum;
            }
            else
            {
                Sum -= sum;
                return Sum;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер кошелька: {number}\nФИО клиента: {clientFIO}\nСрок действия: " +
                $"{validity.Year}.{validity.Month}\nКод безопасности: {secureCode}\nБаланс: {Sum}\n");
        }
    }
}
