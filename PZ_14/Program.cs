using static System.Net.Mime.MediaTypeNames;
using System;

namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"test.txt";
            string line = null;

            Console.WriteLine("Введите построчно содержимое файла (чтобы закончить, введите stop):");

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            {
                using (StreamWriter writer = new StreamWriter(file))
                {

                    while (line != "stop")
                    {
                        writer.WriteLine(line);
                        line = Console.ReadLine();                      
                    }
                }
            }

            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length - 1; i++)
            {
                string str = null;
                int count = i + 1;
                while (count != 0)
                {
                    if (lines[count].Length > lines[count - 1].Length)
                    {
                        str = lines[count];
                        lines[count] = lines[count - 1];
                        lines[count - 1] = str;
                    }
                    count--;
                }
            }

            Console.WriteLine("Перезаписать файл, упорядочив его по возрастанию длины строк? (yes/no)");
            string yes_no = Console.ReadLine();
            if (yes_no == "yes")
            {
                File.Delete(path);
                using (FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(file))
                    {

                        for (int i = 0; i < lines.Length; i++)
                        {
                            writer.WriteLine(lines[i]);
                        }
                    }
                }
            }

            
        }
    }
}
