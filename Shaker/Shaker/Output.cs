﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum SaveMenuComands
{
    ContinueWithCreatFile = 1,
    ContinueWithoutCreatFile = 2,
}

namespace Shaker
{
    internal class Output
    {
        /// <summary>
        /// Сохраняет матрицу в файл
        /// </summary>
        /// <param name="numbers"> Перенная, хранящая матрицу </param>
        public static void SaveArray(List<int> numbers)
        {
            StreamWriter file;
            string filename;
            bool isFileCorrect;

            do
            {
                isFileCorrect = true;
                Console.Write("Введите имя файла: ");
                filename = Console.ReadLine();

                if (!Utils.IsValidFilename(filename))
                {
                    Console.WriteLine($"Ошибка: Неверный формат файла - {filename}");
                    isFileCorrect = false;
                    continue;
                }

                if (Utils.IsFileExist(filename))
                {
                    int userInput;
                    bool isChoiceMade = false;

                    do
                    {
                        Console.WriteLine("Внимание: файла не существует! Желаете создать новый файл с данным именем?");
                        Console.WriteLine("1 - Да.");
                        Console.WriteLine("2 - Нет.");
                        userInput = int.Parse(Console.ReadLine());
                        switch (userInput)
                        {
                            case (int)SaveMenuComands.ContinueWithCreatFile:
                                file = File.CreateText(filename);

                                file.Close();
                                isChoiceMade = true;
                                break;

                            case (int)SaveMenuComands.ContinueWithoutCreatFile:
                                isChoiceMade = true;
                                break;

                            default:
                                Console.WriteLine("Ошибка: некорректный ввод! Повторите попытку ввода.\n");
                                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    while (!isChoiceMade);

                    if (userInput == (int)SaveMenuComands.ContinueWithoutCreatFile)
                        continue;
                }
                else if (Utils.IsReadOnly(filename))
                {
                    Console.WriteLine($"Ошибка: Файл в режиме чтения. Запись невозможна - {filename}");
                    isFileCorrect = false;
                }
            }
            while (!isFileCorrect);

            file = File.AppendText(filename);

            for (int i = 0; i < numbers.Count; i++)
            {
                file.Write(numbers[i] + " ");
            }

            File.WriteAllText(filename, numbers.ToString());

            file.Close();
        }

        /// <summary>
        /// Выводит массив чисел
        /// </summary>
        /// <param name="numbers"></param>
        public static void ShowArray(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }

            Console.WriteLine();
        }

    }
}
