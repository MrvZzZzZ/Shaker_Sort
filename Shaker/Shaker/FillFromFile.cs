﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Shaker
{
    
    internal class FillFromFile
    {
        /// <summary>
        /// Считывает массив из файла
        /// </summary>
        /// <param name="numbers">Массив чисел</param>
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
