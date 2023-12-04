using System;
using System.Collections.Generic;

namespace Shaker
{
    internal class FillRandom
    {
        /// <summary>
        /// Заполнение массива случайными числами
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
        public static void FillArrayRandom(List<int> numbers)
        {
            int _minRandomNumber = -100;
            int _maxRandomNumber = 100;

            Console.WriteLine("Введите размер массива:");
            int arraySize = Utils.GetNumber();

            for (int i = 0; i < arraySize; i++)
            {
                numbers.Add(Utils.GenerateRandomNumber(_minRandomNumber, _maxRandomNumber));
            }
        }
    }
}
