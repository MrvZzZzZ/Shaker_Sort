﻿using System;
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
        public void RunShakerSort(List<int> numbers)
        {
            bool isSwap = false;
            int rightBoarder = numbers.Count - 1, leftBoarder = 0;

            do
            {
                for (int i = leftBoarder; i < rightBoarder; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        int temp = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = temp;
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
                        int temp = numbers[i];
                        numbers[i] = numbers[i - 1];
                        numbers[i - 1] = temp;
                        isSwap = true;
                    }
                }

                leftBoarder++;
            }
            while (leftBoarder < rightBoarder);

            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
