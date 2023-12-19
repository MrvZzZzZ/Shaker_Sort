namespace Shaker
{
    internal class FillRandom
    {
        private List<int> _numbers = new List<int>();

        const int MIN_RANDOM = -100;
        const int MAX_RANDOM = 100;

        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        public List<int> FillArrayRandom()
        {
            Console.WriteLine("Введите размер массива:");
            int arraySize = new Utils().GetNumber();

            for (int i = 0; i < arraySize; i++)
            {
                _numbers.Add(new Utils().GenerateRandomNumber(MIN_RANDOM, MAX_RANDOM));
            }

            return _numbers;
        }
    }
}
