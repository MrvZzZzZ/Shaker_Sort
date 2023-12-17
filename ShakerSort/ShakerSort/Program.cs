namespace Shaker
{
    internal class Program
    {
        /// <summary>
        /// Функция главного меню
        /// </summary>
        static void Main()
        {
            List<int> numbers = new List<int>();
            Utils utils = new Utils();
            ShakerSort shakerSort;
            int userInput;

            do
            {
                Console.WriteLine("Выберите способ заполнения масисва чисел:" +
                    $"\n[{(int)MenuCommands.RandomFillCommand}] Заполнение случайными числами от -100 до 100" +
                    $"\n[{(int)MenuCommands.FileFillCommand}] Заполнение из файла");
                userInput = utils.GetNumber();

                switch (userInput)
                {
                    case (int)MenuCommands.RandomFillCommand:
                        FillRandom fillRandom = new FillRandom();
                        shakerSort = new ShakerSort(numbers = fillRandom.FillArrayRandom());
                        shakerSort.RunShakerSort();
                        break;

                    case (int)MenuCommands.FileFillCommand:
                        FillFromFile fillFromFile = new FillFromFile();
                        shakerSort = new ShakerSort(numbers = fillFromFile.FillArrayFromFile());
                        shakerSort.RunShakerSort();
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню!");
                        break;
                }

                Output output = new Output(numbers);
                output.ShowArray();
                output.SaveArray();
            }
            while (userInput != (int)MenuCommands.RandomFillCommand && userInput != (int)MenuCommands.FileFillCommand);
        }
    }
}
