using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MenuCommand
{
    RandomFillCommand = 1,
    FileFillCommand = 2
}

namespace Shaker
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = new List<int>();
            int userInput;

            do
            {
                Console.WriteLine("Выберите способ заполнения масисва чисел:" +
                    $"\n[{(int)MenuCommand.RandomFillCommand}] Заполнение случайными числами от -100 до 100" +
                    $"\n[{(int)MenuCommand.FileFillCommand}] Заполнение из файла");
                userInput = Utils.GetNumber();

                switch (userInput)
                {
                    case (int)MenuCommand.RandomFillCommand:
                        FillRandom.FillArrayRandom(numbers);
                        ShakerSort.RunShakerSort(numbers);
                        break;

                    case (int)MenuCommand.FileFillCommand:
                        FillFromFile.FillArrayFromFile(numbers);
                        ShakerSort.RunShakerSort(numbers);
                        break;

                    default:
                        Console.WriteLine("Неверный пункт меню!");
                        break;
                }
            }
            while (userInput != (int)MenuCommand.RandomFillCommand && userInput != (int)MenuCommand.FileFillCommand);
        }
    }
}
