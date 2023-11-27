using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker
{
    internal class ShakerSort
    {
        /// <summary>
        /// Запуск шейкерной сортировки
        /// </summary>
        /// <param name="numbers"></param>
        public static void RunShakerSort(List<int> numbers)
        {
            bool isSwap = false;
            int rightBoarder = numbers.Count - 1, leftBoarder = 0;

            do
            {
                for (int i = leftBoarder; i < rightBoarder; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        (numbers[i + 1], numbers[i]) = (numbers[i], numbers[i + 1]);
                        isSwap = true;
                    }
                }

                rightBoarder--;

                if (isSwap == true)
                {
                    isSwap = false;
                    continue;
                }

                for (int i = rightBoarder; i > leftBoarder; i--)
                {
                    if (numbers[i] < numbers[i - 1])
                    {
                        (numbers[i - 1], numbers[i]) = (numbers[i], numbers[i - 1]);
                        isSwap = true;
                    }
                }

                leftBoarder++;
            }
            while (leftBoarder < rightBoarder);

            Output.ShowArray(numbers);
            Console.WriteLine();
        }
    }
}
