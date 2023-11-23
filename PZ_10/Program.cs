namespace PZ_10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст: ");
            string str = Console.ReadLine();

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Можете выйти из программы и вывести полученный текст (введите exit)\n" +
                    " или добавить предложения к своему тексту! Введите их здесь:");
                string new_str = Console.ReadLine();

                if (new_str == "exit")
                    flag = false;
                else
                    str += " " + new_str;
            }
            Console.WriteLine(str);
        }
    }
}