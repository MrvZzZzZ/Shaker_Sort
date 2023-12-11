namespace Shaker
{
    internal class FillFromFile
    {
        /// <summary>
        /// Считывает список из файла
        /// </summary>
        /// <param name="numbers">Список чисел</param>
        public List<int> FillArrayFromFile()
        {
            Console.WriteLine("Введите путь файла: ");
            string filePath = Console.ReadLine() ?? "";

            if (new Utils().CheckFileName(filePath) == false)
            {
                Console.WriteLine($"Ошибка: неверный формат ввода - {filePath}");
            }

            string text = File.ReadAllText($"{filePath}");

            return text.Split(' ').Select(Int32.Parse).ToList();
        }
    }
}
