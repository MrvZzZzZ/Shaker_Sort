using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker
{
    
    internal class FillFromFile
    {
        public static void FillArrayFromFile(List<int> numbers)
        {
            Console.WriteLine("Введите путь файла: ");
            string filePath = Console.ReadLine();
            string[] lines = File.ReadAllLines(filePath);

            for (int i = 0; i < lines.Length; i++)
            {
                int number;
                if (int.TryParse(lines[i], out number))
                {
                    numbers[i] = number;
                }
            }
        }
    }
}
