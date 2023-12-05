namespace PZ_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) //бесконечный цикл для повторного запуска программы
            {
                //рекурсия для первого задания
                static int alg_recurs(int a, int d, int n) 
                {
                    if (n == 1)
                    {
                        return a;
                    }
                    else
                    {
                        return alg_recurs(a, d, n - 1) + d;
                    }
                }

                //рекурсия для второго задания
                static double geo_recurs(double b, double q, int n) 
                {
                    if (n == 1)
                    {
                        return b;
                    }
                    else
                    {
                        return geo_recurs(b, q, n - 1) * q;
                    }
                }

                //рекурсия для третьего задания
                static void A_B_rec1(int A, int B) 
                {
                    if (A <= B)
                    {
                        Console.Write(A + " ");
                        A_B_rec1(A + 1, B);
                    }
                }

                //рекурсия для 4 задания
                static int reverse_num(int num)
                {
                    if (num > 0)
                        return Convert.ToInt32(Convert.ToString(num % 10) + reverse_num(num / 10)); //берем последнюю цифру числа в виде строки,
                                                                                                    //затем снова вызываем функцию, прибавляя последнюю цифру
                    else
                        return 0; //пока число не станет нулем - тогда возвращаем 0 и при вызове функции делим число на 10, чтобы убрать этот ноль
                }

                static void A_B_rec2(int A, int B)
                {
                    if (A >= B)
                    {
                        Console.Write(A + " ");
                        A_B_rec2(A - 1, B);
                    }
                }

                Console.Write("Введите номер задания: ");
                int exercise = Convert.ToInt32(Console.ReadLine());
                int num;
                double res; // ввод основных переменных

                switch (exercise) //выбор программы
                {
                    case 1: //№1

                        int a = -8; 
                        int d = -1;

                        Console.WriteLine($"Первый элемент алгебраической прогрессии a: {a}, шаг d: {d}");
                        Console.Write("Введите n: ");
                        num = Convert.ToInt32(Console.ReadLine());

                        res = alg_recurs(a, d, num); //вызов функции для рекурсии из первого задания
                        Console.WriteLine($"n-й член прогрессии: {Math.Round(res, 0)}");
                        break;

                    case 2: //№2

                        double b = 3; 
                        double q = -0.5;

                        Console.WriteLine($"Первый элемент геометрической прогрессии b: {b}, знаменатель q: {q}");
                        Console.Write("Введите n: ");
                        num = Convert.ToInt32(Console.ReadLine());

                        res = geo_recurs(b, q, num); //вызов функции для рекурсии из второго задания
                        Console.WriteLine($"n-й член прогрессии: {res}");
                        break;

                    case 3: //№3

                        Console.Write("Введите число A: ");
                        int A = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите число B: ");
                        int B = Convert.ToInt32(Console.ReadLine());

                        if (A < B) //условие вывода в порядке возрастания или убывания
                        {
                            A_B_rec1(A, B);
                        }
                        else
                        {
                            A_B_rec2(A, B);
                        }
                        break;

                    case 4: //"задание на 5", №4

                        Console.Write("Введите целое число: ");
                        num = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine($"Ваше число наоборот: {reverse_num(num)/10}"); //вызов функции для рекурсии из 4 задания
                        break;
                }
                Console.WriteLine(); 
            }
        }
    }
}
