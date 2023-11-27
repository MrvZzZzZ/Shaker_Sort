using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shaker
{
    internal class Output
    {
        /// <summary>
        /// Сохраняет матрицу в файл
        /// </summary>
        /// <param name="array"> Перенная, хранящая матрицу </param>
        /// <param name="sizeArray"> Переменная, хранящая размер матрицу </param>
        static void SaveArray(int[] array, int sizeArray)
        {
            StreamWriter file;
            string filename;
            bool isFileCorrect = true;

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

                if (!Utils.IsFileExist(filename))
                {
                    int userInput = 0;
                    bool isChoiceMade = false;

                    do
                    {
                        Console.WriteLine("Внимание: файла не существует! Желаете создать новый файл с данным именем?");
                        Console.WriteLine("1 - Да.");
                        Console.WriteLine("2 - Нет.");
                        userInput = int.Parse(Console.ReadLine());

                        if (userInput == 1)
                        {
                            file = File.CreateText(filename);
                            file.Close();
                            isChoiceMade = true;
                        }
                        else if (userInput == 2)
                        {
                            isChoiceMade = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: некорректный ввод! Повторите попытку ввода.");
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую клавишу для продолжения...");
                            Console.ReadKey();
                        }
                    }
                    while (!isChoiceMade);

                    if (userInput == 2)
                        continue;
                }

                if (!Utils.IsReadOnly(filename))
                {
                    Console.WriteLine($"Ошибка: Файл в режиме чтения. Запись невозможна - {filename}");
                    isFileCorrect = false;
                }
            }
            while (!isFileCorrect);

            file = File.AppendText(filename);

            for (int i = 0; i < sizeArray; i++)
            {
                file.Write(array[i] + " ");
            }

            file.Close();
        }

        public static void ShowArray(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.Write(numbers[i] + " ");
            }
        }
    }
}
