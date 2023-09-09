namespace PZ_01
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
             

            bool flag = true;
            while (flag) //сделаем возможность перезапускать программу через логическую переменную, программа будет работать, пока она равна true
            {
                try //пишем try/catch, чтобы ловить ошибки, если пользователь введет не число в переменные a/b/c
                {
                    //создаём три переменные, которые пользователь введёт в консоль
                    Console.Write("Введите число a: ");
                    double a = double.Parse(Console.ReadLine()); //обязательно парсим в дабл, так как всё, что мы вводим в ридлайн, по умолчанию строка 

                    Console.Write("Введите число b: ");
                    double b = double.Parse(Console.ReadLine());
                    if (b == 0)
                    {
                        Console.WriteLine("b не может быть равна 0, попробуйте заново :("); // sin(b) находится в знаменателе, поэтому b не может быть равен 0
                    }

                    Console.Write("Введите число c: ");
                    double c = double.Parse(Console.ReadLine());

                    double num1, num2, num3; // для удобства я разбил выражение на 3 основных числа, 2 из которых я в конце вычту из третьего

                    // далее провожу все операции, где надо, используя Math.
                    num1 = Math.Abs(Math.Pow(a, 2) - Math.Pow(b, 2)) / Math.Sin(b);

                    num2 = Math.Pow(10, 4) * Math.Pow(Math.Abs(Math.Sin(a + b) - b * c), 1 / 5);

                    num3 = (4 - Math.Tan(a)) / Math.Pow(Math.E, 3);

                    Console.WriteLine(num1 - num2 - num3); // в конце вычитаю те самые два числа из третьего
                }

                catch (System.FormatException)
                {
                    Console.WriteLine("Вы ввели не число :<"); //вывод сообщения при ошибке
                }

                Console.WriteLine("Хотите ввести другие числа? (y/n)");// спрашиваем пользователя, хочет ли он перезапустить программу

                string end = Console.ReadLine();

                if (end == "n") // если он отвечает нет (n), то даем нашей переменной flag значение false и программа заканчивает работу
                {
                    flag = false;
                }
            }

            
            

            

        }
    }
}