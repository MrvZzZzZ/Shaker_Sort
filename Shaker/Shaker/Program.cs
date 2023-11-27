using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ConsoleFillCommand = 1;
            const int FileFillCommand = 2;


            List<int> numbers = new List<int>();
            int userInput = 0;

            do
            {
                Console.WriteLine("Выберите способ заполнения масисва чисел:" +
                    $"\n [{ConsoleFillCommand}] Заполнение случайными числами от -100 до 100" +
                    $"\n [{FileFillCommand}] Заполнение из файла");
                userInput = Utils.GetNumber();

                switch (userInput)
                {
                    case ConsoleFillCommand:
                        //
                        break;
                    case FileFillCommand:
                        //
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню!");
                        break;
                }
            }
            while (userInput != ConsoleFillCommand && userInput != FileFillCommand);
        }
    }
}
