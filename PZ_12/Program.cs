namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите e-mail: ");
            string email = Console.ReadLine();

            
            
            static bool isEmail(string email)
            {
                string domainName = email.Substring(email.LastIndexOf("@"));
                string name = email.Remove(email.LastIndexOf("@"));


                if (domainName == "@mail.ru" && name.Length <= 64 && !name.Contains("@") && !name.Contains(" "))
                    return true;
                else
                    return false;
            }

            

            bool isCorrectEmail = isEmail(email);

            Console.WriteLine(isCorrectEmail);
        }
    }
}
