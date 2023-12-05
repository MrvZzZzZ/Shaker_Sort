using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shaker
{
    
    internal class FillFromFile
    {
        /// <summary>
        /// Считывает список из файла
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public static void FillArrayFromFile(List<int> numbers)
        {
            Console.WriteLine("Введите путь файла: ");
            string filePath = Console.ReadLine();
            string lines = File.ReadAllText($"{filePath}");

            List<int> numbersToList = lines.Split(' ').Select(Int32.Parse).ToList();

            foreach (int number in numbersToList)
            {
                numbers.Add(number);
            }
        }
    }
}
