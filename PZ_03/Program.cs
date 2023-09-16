namespace PZ_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) //бесконечный цикл, чтобы программа перезапускалась
            {

            

                Console.WriteLine("Выберите день недели(1-7): ");//выбор дня недели
                uint dayOfWeek = uint.Parse(Console.ReadLine());

                int trainRoute, count;//вспомогательные переменные
                count = 0;

                if (dayOfWeek == 1 || dayOfWeek == 2 || dayOfWeek == 3 || dayOfWeek == 4 || dayOfWeek == 5)
                {
                    count = 1;
                }
                else
                {
                    if (dayOfWeek == 6 || dayOfWeek == 7)
                        count = 2;
                    else
                        Console.WriteLine("Вы некорректно ввели день недели :( Попробуйте еще раз");
                }

                switch (count) //реализация свича для определенного дня недели и маршрута
                {
                    case 1:
                        Console.WriteLine("Выберите Маршрут(1-5):\nМаршрут 1\nМаршрут 2\nМаршрут 3\nМаршрут 4\nМаршрут 5");
                        trainRoute = int.Parse(Console.ReadLine());

                        switch (trainRoute)
                        {
                            case 1:
                                Console.WriteLine("Стоимость билета: 30р");
                                break;
                            case 2:
                                Console.WriteLine("Стоимость билета: 25р");
                                break;
                            case 3:
                                Console.WriteLine("Стоимость билета: 40р");
                                break;
                            case 4:
                                Console.WriteLine("Стоимость билета: 21р");
                                break;
                            case 5:
                                Console.WriteLine("Стоимость билета: 24р");
                                break;
                            default:
                                Console.WriteLine("Вы некорректно выбрали маршрут:( Попробуйте еще раз");
                                break;

                        }
                        break;
                    case 2:
                        Console.WriteLine("Выберите Маршрут(6-10):\nМаршрут 6\nМаршрут 7\nМаршрут 8\nМаршрут 9\nМаршрут 10");
                        trainRoute = int.Parse(Console.ReadLine());

                        switch (trainRoute)
                        {
                            case 6:
                                Console.WriteLine("Стоимость билета: 50р");
                                break;
                            case 7:
                                Console.WriteLine("Стоимость билета: 52р");
                                break;
                            case 8:
                                Console.WriteLine("Стоимость билета: 47р");
                                break;
                            case 9:
                                Console.WriteLine("Стоимость билета: 26р");
                                break;
                            case 10:
                                Console.WriteLine("Стоимость билета: 29р");
                                break;
                            default:
                                Console.WriteLine("Вы некорректно выбрали маршрут:( Попробуйте еще раз");
                                break;




                        }
                        break;
                }

                Console.ReadLine();
                Console.Clear();

            }
        }
    }
}