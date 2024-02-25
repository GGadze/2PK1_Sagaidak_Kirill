using System.Reflection.Metadata;
using System;

namespace consoleProject
{
    /*
     * ФИО студента: Сагайдак Кирилл Дмитриевич
     * номер варианта: 18
     * условие задачи (скопировать из листа задания): За основу берется класс, разработанный на 17 практике (создание простого класса).
Для этого класса необходимо реализовать следующие интерфейсы:
1. IClonable с реализацией глубокого копирования (если присутствуют ссылочные
поля)
2. IComporable (по какому из полей будет производится сравнение объектов –
выбираете на свое усмотрение, главное адекватность. Например, сравнение
посылок по весу, пользователей по дате регистрации и т.д.)
Создать массив/список на 10 объектов данного класса и отсортировать эту
коллекцию через стандартный метод Sort()
3. IDisposable. (разбор самостоятельный здесь)
4. Создать пользовательский интерфейс, в который вынести контракт на реализацию
специфичного для вашего класса функционала (например, для пользователя
ресурса (IUser) это может быть идентификатор(свойство) регистрация(метод)
удаление аккаунта (метод)).
Создать новый класс, в котором реализовать данный интерфейс.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card(1234123412341234, "Кузнецов Иван Бякбякович",
               new DateTime(2026, 05, 19), 520, Type.credit);

            var card2 = (Card)card1.Clone();
            card2.secureCode = 400;
            card2.number = 7463547586908752;

            Card card3 = new Card(0987364537128294, "Иванов Сергей Александрович",
               new DateTime(2025, 02, 25), 593, Type.debit);
            Card card4 = new Card(9738403927354671, "Сагайдак Егор Алексеевич",
               new DateTime(2028, 09, 03), 617, Type.debit);
            Card card5 = new Card(1983633890047254, "Анпилогов Алексей Магомедович",
               new DateTime(2024, 05, 22), 826, Type.credit);
            Card card6 = new Card(5643789021235436, "Яценко Жабка Барсиковна",
               new DateTime(2027, 01, 15), 290, Type.debit);
            Card card7 = new Card(1287653209876453, "Барсиков Замай Арманович",
               new DateTime(2026, 05, 19), 899, Type.credit);
            Card card8 = new Card(9877245653421234, "Шкуратов Замир Егорович",
               new DateTime(2027, 05, 19), 142, Type.debit);
            Card card9 = new Card(1234567899876543, "Скоморохова Мария Николаевна",
               new DateTime(2026, 05, 19), 522, Type.credit);
            Card card10 = new Card(834773297384234, "Селиверстов Сергей Андреевич",
            new DateTime(2028, 05, 19), 904, Type.debit);


            card1.PrintInfo();
            card2.PrintInfo();
            Console.WriteLine("\n\n");

            Card[] cards = { card1, card2, card3, card4, card5, card6, card7, card8, card9, card10 };
            Array.Sort(cards);

            foreach (Card card in cards)
            {
                card.PrintInfo();
            }


            card6.Dispose();
            Console.WriteLine("\n");


            YooMoney yWallet1 = new YooMoney(0987364537128294, "Иванов Сергей Александрович",
               new DateTime(2025, 02, 25), 593);

            yWallet1.AddMoney(5000);
            card5.AddMoney(25000);

            yWallet1.PrintInfo();
            card5.PrintInfo();

            yWallet1.DecMoney(3000);
            yWallet1.PrintInfo();
        }
    }
}