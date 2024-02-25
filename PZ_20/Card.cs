using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace consoleProject
{
    enum Type { debit, credit }
    internal class Card : ICloneable, IComparable<Card>, IDisposable, IWallet
    {
        public int Sum { get; set; }

        public long number;
        public string clientFIO;
        public DateTime validity;
        public int secureCode;
        public Type type;

        public Card(long number, string clientFIO, DateTime validity, int secureCode, Type type)
        {
            this.number = number;
            this.clientFIO = clientFIO;
            this.validity = validity;
            this.secureCode = secureCode;
            this.type = type;
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

        public object Clone()
        {
            return new Card(number, clientFIO,validity, secureCode, type);
        }

        public int CompareTo(Card? c)
        {
            return secureCode.CompareTo(c.secureCode);
        }

        public void Dispose()
        {
            Console.WriteLine($"Карта с номером {number} была утилизирована");
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Номер карты: {number}\nФИО клиента: {clientFIO}\nСрок действия: " +
                $"{validity.Year}.{validity.Month}\nКод безопасности: {secureCode}\nТип карты: {type}\nБаланс: {Sum}\n");
        }
    }
}
