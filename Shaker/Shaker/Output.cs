using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum SaveMenuComands
{ 
    ContinueWithSave = 1,
    ContinueWithoutSave = 2,
}

namespace Shaker
{
    internal class Output
    {
        /// <summary>
        /// Сохраняет матрицу в файл
        /// </summary>
        /// <param name="numbers"> Перенная, хранящая матрицу </param>
        /// <param name="sizeArray"> Переменная, хранящая размер матрицу </param>
        static public void SaveArray(List<int> numbers)
        {
            StreamWriter file;
            string filename;
            bool isFileCorrect;

            do
            {
                isFileCorrect = true;
                int userInput;
                Console.Write("\nДля сохранения введите путь файла: ");
                filename = Console.ReadLine();

                if (!Utils.IsValidFilename(filename))
                {
                    Console.WriteLine($"Ошибка: Неверный формат файла - {filename}");
                    isFileCorrect = false;
                    continue;
                }

                if (!Utils.IsFileExist(filename))
                {
                    bool isChoiceMade = false;

                    do
                    {
                        Console.WriteLine("Внимание: файла не существует! Желаете создать новый файл с данным именем?");
                        Console.WriteLine("1 - Да.");
                        Console.WriteLine("2 - Нет.");
                        userInput = Utils.GetNumber();

                        switch (userInput)
                        {
                            case (int)SaveMenuComands.ContinueWithSave:
                                file = File.CreateText(filename);
                                file.Close();
                                isChoiceMade = true;
                                break;

                            case (int)SaveMenuComands.ContinueWithoutSave:
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

                    if (userInput == (int)SaveMenuComands.ContinueWithoutSave)
                        continue;
                }
                else if (Utils.IsReadOnly(filename))
                {
                    Console.WriteLine($"Ошибка: Файл в режиме чтения. Запись невозможна - {filename}");
                    isFileCorrect = false;
                }
                else
                {
                    Console.WriteLine("Выберите способ записи:\n" +
                        "[1] Дописать в файл\n" +
                        "[2] Перезаписить файл");
                    userInput = Utils.GetNumber();

                    switch (userInput)
                    {
                        case 1:
                            file = File.AppendText(filename);
                            file.Write(" ");
                            break;

                        case 2:
                            file = File.CreateText(filename);
                            file.Close();
                            break;

                        default:
                            break;
                    }

                }
            }
            while (!isFileCorrect);

            file = File.AppendText(filename);

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                file.Write(numbers[i] + " ");
            }

            file.Write(numbers[numbers.Count - 1]);

            file.Close();
        }

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
