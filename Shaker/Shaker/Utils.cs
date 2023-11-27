using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Shaker
{
    internal class Utils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber);
        }

        public static int GenerateRandomNumber(int maxNumber)
        {
            return s_random.Next(maxNumber);
        }

        public static int GetNumber()
        {
            int number;
            string word = Console.ReadLine();

            while (int.TryParse(word, out number) == false)
            {
                Console.WriteLine("Ошибка, введите число:  ");
                word = Console.ReadLine();
            }

            return number;
        }

        public static string GetString()
        {
            string userInput;

            while (true)
            {
                userInput = Console.ReadLine();
                Regex emptyInputPattern = new Regex("(\\s*)");

                if (emptyInputPattern.IsMatch(userInput) == false) //!
                {
                    Regex correctSymbolPattern = new Regex("^[а-яА-ЯёЁa-zA-Z0-9/:._ ]+$");

                    if (correctSymbolPattern.IsMatch(userInput))
                    {
                        Regex allowedNamesPattern = new Regex("\\b(con|aux|prn|com|lpt|nul)\\b((\\.)*(\\w)*)*");

                        for (int i = 0; i < userInput.Length; i++)
                        {
                            userInput = userInput.ToLower();
                        }

                        if (allowedNamesPattern.IsMatch(userInput) == false) //!
                        {
                            return userInput;
                        }
                        else Console.WriteLine("Ошибка: вы ввели зарезервированное имя. Повторите попытку ввода.");
                    }
                    else Console.WriteLine("Ошибка: вы ввели запрещенный символ. Повторите попытку ввода.");
                }
                else Console.WriteLine("Ошибка: вы оставили ввод пустым. Повторите попытку ввода.");
            }
        }

        public static bool IsValidFilename(string filename)
        {
            Regex pattern = new Regex(".+\\.txt$");
            return pattern.IsMatch(filename);
        }

        public static bool IsReadOnly(string filename)
        {
            return (File.GetAttributes(filename) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        public static bool IsFileExist(string filename)
        {
            return File.Exists(filename);
        }
    }
}
