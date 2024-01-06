using System.Reflection;

namespace OTUS_L5_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string strVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string strDate = File.GetCreationTime(Assembly.GetExecutingAssembly().Location).ToString();

            bool exit = true;
            string userName = null;
            Console.WriteLine("Telegram Menu Demo \r\n" +
                                "   /start -- начало работы с доступом к дополнительному меню,\r\n" +
                                "   /help  -- выводит краткую справочную информацию о том, как пользоваться программой,\r\n" +
                                "   /info  -- информация о версии программы и дате её создания,\r\n" +
                                "   /exit  -- выход из программы.\r\n"+
                                " Дополнительное меню:\r\n"+
                                "   /echo произвольная_строка -- выводит произвольную строку, доступна после ввода имени\r\n" +
                                "                                пользователя"
                );
            while (exit)
            {
                Console.Write("--> ");
                var commandString = Console.ReadLine();
                string[] words = commandString.Split(' ');
                string command = words[0];
                string[] freeString = words[1..];
                switch (command)
                {
                    case "/exit":
                        exit = false;
                        break;
                    case "/help":
                        Console.Clear();
                        if (userName != null)
                            Console.WriteLine("{0}, инофрмация по команде:", userName);
                        Console.WriteLine("Telegram Menu Demo > help\r\n" +
                                            "   Для начала работы с основным меню необходимо ввести команду /start, затем ввести Ваше имя.\r\n" +
                                            "   После данной процедуры можно будет воспользоваться командой /echo основного меню."
                            );
                        break;
                    case "/info":
                        Console.Clear();
                        if (userName != null)
                            Console.WriteLine("{0}, инофрмация по команде:", userName);
                        Console.WriteLine("Telegram Menu Demo > info\r\n" +
                                            "   Версия сборки приложения {0}, дата сборки приложения {1}", strVersion, strDate
                            );
                        break;
                    case "/start":
                        if (userName == null)
                        {
                            Console.Clear();
                            Console.WriteLine("Как тебя зовут?");
                            userName = Console.ReadLine();
                            Console.WriteLine("Рад познакомиться, " + userName + "!\r\n" +
                                                "   теперь тебе доступна еще одна команда /echo."
                                );
                        }
                        else
                        {
                            Console.WriteLine("{0}, я знаю как тебя зовут!", userName);
                            Console.WriteLine("   Введи другую команду.");
                        }
                        break;
                    case "/echo":
                        if (userName != null)
                        {
                            Console.Clear();
                            if (userName != null)
                                Console.WriteLine("{0}, инофрмация по команде:", userName);
                            Console.Write("--> ");
                            if (words.Length < 2)
                                Console.WriteLine("Введенная произвольная строка пуста.");
                            else
                                foreach (string word in freeString)
                                    Console.Write(word + " ");
                            Console.WriteLine();
                        }
                        break;

                }
            }
        }
    }
}