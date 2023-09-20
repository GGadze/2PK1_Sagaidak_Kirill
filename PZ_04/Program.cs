namespace PZ_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //задание первое
            Console.WriteLine("№1");
            for (int i = 20; i <= 100; i += 4)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine();

            //задание второе
            Console.WriteLine("№2");
            for (char i = 'Е'; i <= 'К'; i++)
            {
                Console.Write(i+" ");
            }

            Console.WriteLine();
            Console.WriteLine();

            //задание третье
            Console.Write("№3");
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < 6; j++)
                {
                    Console.Write('#');
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            //задание четвертое
            Console.Write("№4");
            int count = 0;
            Console.WriteLine();
            for (int i = 90; i <= 900; i++)
            {
                
                if (i % 5 == 0)
                {
                    Console.Write(i + " ");
                    count++;
                }
                
            }
            Console.WriteLine();
            Console.WriteLine($"Количество чисел кратных 5: {count}");

            Console.WriteLine();

            //задание пятое
            Console.WriteLine("№5");
            int a, b;
            
            for (a = 5,  b = 99; b - a > 4; a++, b--)
            {
                Console.WriteLine(a + " " + b);
            }

            Console.WriteLine(a + " " + b);

        }
    }
}