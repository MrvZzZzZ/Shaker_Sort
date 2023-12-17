using System.Text.RegularExpressions;

namespace Shaker
{
    internal class Utils
    {
        private Random _random = new Random();

        /// <summary>
        /// Генерация случайного числа от указанного минимума до указанного максимума
        /// </summary>
        /// <param name="minNumber">Минимальная граница для случайного числа</param>
        /// <param name="maxNumber">Максимальная граница для случайного числа</param>
        /// <returns>Случайное число</returns>
        public  int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            return _random.Next(minNumber, maxNumber);
        }

        /// <summary>
        /// Получение числа от пользователя
        /// </summary>
        /// <returns>Пользовательское число</returns>
        public int GetNumber()
        {
            int number;
            string? word = Console.ReadLine();

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
        /// <param name="userInput">Пользовательский воод</param>
        /// <returns>Флаг проверки на символы, зарезервированное имя и пустой ввод</returns>
        public bool CheckFileName(string userInput)
        {
            while (true)
            {
                userInput = Console.ReadLine() ?? "";
                Regex emptyInputPattern = new Regex("(\\s*)");

                if (emptyInputPattern.IsMatch(userInput) == false)
                {
                    Regex correctSymbolPattern = new Regex("^[а-яА-ЯёЁa-zA-Z0-9/:._ ]+$");

                    if (correctSymbolPattern.IsMatch(userInput))
                    {
                        return true;
                    }
                }
                
                return false;
            }
        }

        /// <summary>
        /// Проверка на корректность имени файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Флаг корректности имени файла</returns>
        public bool IsValidFileName(string fileName)
        {
            Regex pattern = new Regex(".+\\.txt$");
            return pattern.IsMatch(fileName);
        }

        /// <summary>
        /// Проверка файла на "Только чтение"
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Флаг проверки файла на только чтение</returns>
        public bool IsReadOnly(string fileName)
        {
            return (File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly;
        }

        /// <summary>
        /// Проверка на существование файла
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Флаг проверки файла на существовние файла</returns>
        public bool IsFileExist(string fileName)
        {
            return File.Exists(fileName);
        }
    }
}
