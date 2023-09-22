namespace PZ_05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double x = -4.0;
            double h = 0.5;
            double y;

            while (x <= 4)
            {

                Console.Write($"x: {x} ");
                if (x == Math.Truncate(x))
                {
                    Console.Write("  ");
                }
                Console.Write("| ");
                y = Math.Abs(x);
                Console.WriteLine($"y: {y}");
                Console.WriteLine();
                x += h;
            }


        }
    }
}