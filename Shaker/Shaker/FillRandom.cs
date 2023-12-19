using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker
{
    internal class FillRandom
    {
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
