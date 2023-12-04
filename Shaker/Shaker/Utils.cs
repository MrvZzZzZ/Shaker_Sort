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
        
        /// <summary>
        /// Генерация случайного числа от указанного минимума до указанного максимума
        /// </summary>
        /// <param name="minNumber">Минимальная граница для случайного числа</param>
        /// <param name="maxNumber">Максимальная граница для случайного числа</param>
        /// <returns>Случайное число</returns>
        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber);
        }
        /// <summary>
        /// Генерация случайного числа от 0 до указанного максимума
        /// </summary>
        /// <param name="maxNumber">Максимальная граница для случайного числа</param>
        /// <returns>Случайное число</returns>
        public static int GenerateRandomNumber(int maxNumber)
        {
            return s_random.Next(maxNumber);
        }

        /// <summary>
        /// Получение числа от пользователя
        /// </summary>
        /// <returns>Пользовательское число</returns>
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
        /// <summary>
        /// Получение корректной строки от пользователя
        /// </summary>
        /// <returns>Пользовательская строка</returns>
        public static string GetString()
        {
            string userInput;

            while (true)
            {
                userInput = Console.ReadLine();
                Regex emptyInputPattern = new Regex("(\\s*)");

                if (emptyInputPattern.IsMatch(userInput) == false)
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

        /// <summary>
        /// Проверка на корректность имени файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Булевое значение</returns>
        public static bool IsValidFilename(string filename)
        {
            Regex pattern = new Regex(".+\\.txt$");
            return pattern.IsMatch(filename);
        }

        /// <summary>
        /// Проверка файла на "Только чтение"
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Булевое значение</returns>
        public static bool IsReadOnly(string filename)
        {
            return (File.GetAttributes(filename) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        /// <summary>
        /// Проверка на существование файла
        /// </summary>
        /// <param name="filename">Имя файла</param>
        /// <returns>Булевое значение</returns>
        public static bool IsFileExist(string filename)
        {
            return File.Exists(filename);
        }
    }
}
