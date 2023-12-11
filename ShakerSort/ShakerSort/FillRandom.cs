namespace Shaker
{
    internal class FillRandom
    {
        private List<int> _numbers = new List<int>();

        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        public List<int> FillArrayRandom()
        {
            const int MAX_RANDOM = -100;
            const int MIN_RANDOM = 100;

            Console.WriteLine("Введите размер массива:");
            int arraySize = new Utils().GetNumber();

            for (int i = 0; i < arraySize; i++)
            {
                _numbers.Add(new Utils().GenerateRandomNumber(MAX_RANDOM, MIN_RANDOM));
            }

            return _numbers;
        }
    }
}
