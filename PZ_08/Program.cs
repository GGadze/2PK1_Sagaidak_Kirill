using System;

namespace PZ_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            char[] [] chars = new char[4] [];
            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = new char [rnd.Next(10, 16)];
            }

            string rndStr = "qwertyuiopasdfghjklzxcvbnm1234567890";

            Console.WriteLine("Сгенерированный массив:");

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars[i].Length; j++)
                {
                    chars[i][j] = rndStr[rnd.Next(rndStr.Length)];
                    Console.Write(chars[i][j] + " ");
                }
                Console.WriteLine();
            }

            char[] chars1 = new char[4];

            Console.WriteLine("№3.Последние элементы массива:");

            for (int i = 0; i < chars1.Length; i++)
            {
                chars1[i] = chars[i][^1];
                Console.Write(chars1[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("№4.Максимальные элементы массива:");

            for (int i = 0; i < chars1.Length; i++)
            {
                chars1[i] = chars[i].Max();
                Console.Write(chars1[i] + " ");
            }

            Console.WriteLine();
            Console.WriteLine("№5.Полученный массив:");

            for (int i = 0; i < chars.Length; i++)
            {
                char b = chars[i][0];
                char c = chars[i].Max();
                int n = Array.IndexOf(chars[i], c);
                chars[i][0] = c;
                chars[i][n] = b;
            }

            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars[i].Length; j++)
                {
                    Console.Write(chars[i][j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("№6.Полученный реверснутый массив:");

            for (int i = 0; i < chars.Length; i++)
            {
                char[] chars2 = new char[chars[i].Length];
                for (int j = 0; j < chars[i].Length; j++)
                {
                    
                    chars2[j] = chars[i][j];
                }

                Array.Reverse(chars2);
                for (int j = 0; j < chars2.Length; j++)
                {
                    Console.Write(chars2[j] + " ");
                }

                Console.WriteLine();

            }

            Console.WriteLine("№7.Наиболее встречающиеся символы:");

            int count;
            int count1;
            char k = 'a';
             
            for (int i = 0; i < chars.Length; i++) 
            {
                
                count1 = 0;

                for (int j = 0; j < chars[i].Length; j++)                                                        
                {
                    count = 0;
                    
                    for (int l = 0; l < chars[i].Length; l++)
                    {
                        if (chars[i][j] == chars[i][l])
                        {
                            count++;
                        }
                        if (count > count1)
                        {
                            count1 = count;
                            k = chars[i][j];
                        }
                    }
                }
                Console.WriteLine($"Наиболее часто встречается символ '{k}'\nОн встречается {count1} раз");
            }
        }
    }
}