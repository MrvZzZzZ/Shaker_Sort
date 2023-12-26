namespace WebSort.Controllers
{
    public class Utils
    {
        /// <summary>
        /// Проверка отсортирован ли массив
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Флаг значения сортировки</returns>
        public bool IsSorted(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Конвертация списка чисел в строку
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Строка чисел через пробел</returns>
        public string ConvertIntListToString(List<int> numbers)
        {
            return string.Join(" ", numbers);
        }
        /// <summary>
        /// Проверка на содержание букв
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Флаг содержания букв</returns>
        public bool ContainsLetters(string input)
        {
            foreach (char c in input)
            {
                if (char.IsLetter(c))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
