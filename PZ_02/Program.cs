namespace PZ_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //делаем бесконечный цикл, чтобы по окончанию программа начиналась заново
            while (true)
            {

                try //ловим ошибки
                {


                    //объявляем и вводим с консоли переменные 
                    double s, p, z;

                    Console.Write("Введите значение a: ");
                    int a = int.Parse(Console.ReadLine());

                    Console.Write("Введите значение h: ");
                    double h = double.Parse(Console.ReadLine());

                    Console.Write("Введите значение x: ");
                    double x = double.Parse(Console.ReadLine());
                    
                    if (a + h < 0) //проверка подкоренного выражения на отрицательное значение 
                    {
                        Console.WriteLine("Неверное значение! Сумма a и h не должна быть меньше нуля!");

                        break;
                    }
                        
                    //вычисления 
                    if (h > 3)
                        s = h * Math.Cos(Math.Sqrt(a + h));
                    else
                        s = h * Math.Sin(a + Math.PI) + 0.5 * a;

                    if (x > 0.7)
                        p = Math.Pow(Math.E, (a - s)) + Math.Pow(x, 2) - h;
                    else
                        p = Math.Pow(h, 2) + 4 * Math.Sin(a + x) + x;

                    z = 0.1 * a * Math.Pow(h, 3) - 0.3 * s * Math.Pow(p, 3);
                    //вывод на консоль 
                    Console.WriteLine($"Значение s равно {Math.Round(s, 2)}");
                    Console.WriteLine($"Значение p равно {Math.Round(p, 2)}");
                    Console.WriteLine($"Значение z равно {Math.Round(z, 2)}");

                    Console.ReadLine();

                    Console.Clear();

                }

                catch (System.Exception)
                {
                    Console.WriteLine("Вы некорректно ввели число :(");

                    Console.ReadLine();

                    Console.Clear();
                }

                

            }

        }
    }
}
