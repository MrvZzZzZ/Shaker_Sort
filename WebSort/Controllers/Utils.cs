namespace WebSort.Controllers
{
    public class Utils
    {
        public bool IsSorted(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] > numbers[i + 1])
                {
                    Console.WriteLine("Массив не отсортирован!");
                    return false;
                }
            }

            return true;
        }

		public string ConvertIntListToString(List<int> numbers)
		{
			return string.Join(" ", numbers);
		}
	}
}
