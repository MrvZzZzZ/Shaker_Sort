using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaker
{
    internal class Utils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber);
        }

        public static int GenerateRandomNumber(int maxNumber)
        {
            return s_random.Next(maxNumber);
        }

        public static int GetNumber()
        {
            int number;
            string word = Console.ReadLine();

            while (int.TryParse(word, out number) == false)
            {
                Console.WriteLine("Ошибка, введите число:  ");
                word = Console.ReadLine();
            }

            return number;
        }
    }

}
