using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

enum MenuCommand
{
    RandomFillCommand,
    FileFillCommand
}

namespace Shaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            int userInput = 0;

            do
            {
                Console.WriteLine("Выберите способ заполнения масисва чисел:" +
                    $"\n [{MenuCommand.RandomFillCommand}] Заполнение случайными числами от -100 до 100" +
                    $"\n [{MenuCommand.FileFillCommand}] Заполнение из файла");
                userInput = Utils.GetNumber();

                switch (userInput)
                {
                    case (int)MenuCommand.RandomFillCommand:
                        FillRandom.FillArrayRandom(numbers);
                        break;

                    case (int)MenuCommand.FileFillCommand:
                        FillFromFile.FillArrayFromFile(numbers);
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
