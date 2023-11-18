namespace PZ_09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string vowels = "eiyuoa"; //строка гласных букв, чтобы позже сделать проверку
                                      //на то, какая буква в конце слова

            Console.WriteLine("Введите строку:");
            string str = Console.ReadLine();

            string[] words = str.Split(' ');//разделил строку на подстроки из слов

            int count_vowels = 0;//счетчики для количества гласных
            int count_consonants = 0;//и согласных

            double number_of_letters = 0;//переменная для подсчета общего количества букв в строке

            for (int i = 0; i < words.Length; i++)//проходим по каждому слову
            {
                if (vowels.Contains(Char.ToLower(words[i][words[i].Length - 1])))/*проверка,
                    принадлежит ли последний символ каждого слова нашей строке гласных*/

                    count_vowels++; //если да - плюсуем счетчик гласных
                else
                    count_consonants++;//в ином случае плюсуем счетчик согласных

                number_of_letters += words[i].Length;/*каждый раз прибавляем к общему количеству букв
                                                     количество букв в каждом слове*/
            }

            double average_value = Math.Round(number_of_letters/words.Length, 2);
            //переменная для среднего значения букв

            Console.WriteLine($"Слова, заканчивающиеся на coгласную букву: {count_consonants}\n" +
                $"Слова, заканчивающиеся на гласную букву: {count_vowels}\n" +
                $"Среднее количество символов в словах строки: {average_value}"); //вывод полученных данных
        }
    }
}