namespace PZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите три числа в произовльном порядке\nПераое: ");
            double a1 = double.Parse(Console.ReadLine());

            Console.Write("Второе: ");
            double b1 = double.Parse(Console.ReadLine());

            Console.Write("Третье: ");
            double c1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Отсортированный список чисел:");
            SortDec3(a1, b1, c1);

            Console.Write("\nА теперь введите еще три\nПервое: ");
            double a2 = double.Parse(Console.ReadLine());

            Console.Write("Второе: ");
            double b2 = double.Parse(Console.ReadLine());

            Console.Write("Третье: ");
            double c2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Отсортированный список чисел:");
            SortDec3(a2, b2, c2);

            Console.WriteLine($"{a1} {b1} {c1}");

            static void SortDec3(double a, double b, double c)
            {
                double num;

                if (a >= b && a <= c)
                {
                    num = b;
                    b = a;
                    a = c;
                    c = num;

                }
                else if (a <= b && a >= c)
                {
                    num = a;
                    a = b;
                    b = num;
                }
                else if (c >= b && b >= a)
                {
                    num = a;
                    a = c;
                    c = num;
                }
                else if (b >= c && c >= a)
                {
                    num = a;
                    a = b;
                    b = c;
                    c = num;
                }
                else if (a >= c && c >= b)
                {
                    num = b;
                    b = c;
                    c = num;
                }
                else { }

                Console.Write($"a: {a}\nb: {b}\nc: {c}");
            }
        }
    }
}
