namespace Shaker
{
    internal class Output
    {
        private List<int> _numbers;

        public Output(List<int> numbers) 
        {
            _numbers = numbers;
        }

        /// <summary>
        /// Сохраняет матрицу в файл
        /// </summary>
        public void SaveArray()
        {
            StreamWriter file;
            string fileName;
            bool isFileCorrect;

            do
            {
                isFileCorrect = true;
                int userInput;
                Console.Write($"\nДля сохранения введите путь файла: ");
                fileName = Console.ReadLine() ?? "";

                if (new Utils().CheckFileName(fileName) == false)
                {
                    Console.WriteLine($"Ошибка: неверный формат ввода - {fileName}");
                }

                if (new Utils().IsValidFileName(fileName) == false)
                {
                    Console.WriteLine($"Ошибка: Неверный формат файла - {fileName}");
                    isFileCorrect = false;
                    continue;
                }

                if (new Utils().IsFileExist(fileName) == false)
                {
                    bool isChoiceMade = false;

                    do
                    {
                        Console.WriteLine("Внимание: файла не существует! Желаете создать новый файл с данным именем?");
                        Console.WriteLine("[1] - Да.");
                        Console.WriteLine("[2] - Нет.");
                        userInput = new Utils().GetNumber();

                        switch (userInput)
                        {
                            case (int)SaveMenuComands.ContinueWithSaveCommand:
                                file = File.CreateText(fileName);
                                file.Close();
                                isChoiceMade = true;
                                break;

                            case (int)SaveMenuComands.ContinueWithoutSaveCommand:
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

                    if (userInput == (int)SaveMenuComands.ContinueWithoutSaveCommand)
                        continue;
                }
                else if (new Utils().IsReadOnly(fileName))
                {
                    Console.WriteLine($"Ошибка: Файл в режиме чтения. Запись невозможна - {fileName}");
                    isFileCorrect = false;
                }
                else
                {
                    Console.WriteLine("Выберите способ записи:\n" +
                        "[1] Дописать в файл\n" +
                        "[2] Перезаписить файл");
                    userInput = new Utils().GetNumber();

                    switch (userInput)
                    {
                        case (int)SaveWayCommands.FileAddCommand:
                            file = File.AppendText(fileName);
                            file.Write(" ");
                            break;

                        case (int)SaveWayCommands.OverwriteFileCommand:
                            file = File.CreateText(fileName);
                            file.Close();
                            break;

                        default:
                            break;
                    }

                }
            }
            while (!isFileCorrect);

            file = File.AppendText(fileName);

            for (int i = 0; i < _numbers.Count - 1; i++)
            {
                file.Write(_numbers[i] + " ");
            }

            file.Write(_numbers[_numbers.Count - 1]);

            file.Close();
        }

        /// <summary>
        /// Вывод массива чисел
        /// </summary>
        public void ShowArray()
        {
            for (int i = 0; i < _numbers.Count; i++)
            {
                Console.Write(_numbers[i] + " ");
            }

            Console.WriteLine();
        }
    }
}
