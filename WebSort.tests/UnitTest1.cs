using WebSort;
using WebSort.Controllers;

namespace WebSort.tests
{
    [TestClass]
    public class UnitTest1
    {
		private void SendArrays(List<int> numbers)
		{
			Utils utils = new Utils();
			ArrayRepository arrayRepository = new ArrayRepository("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False");
			Array array = new Array();

			array.Numbers = utils.ConvertIntListToString(numbers);

			if (utils.IsSorted(numbers))
			{
				array.SortStatus = true;
			}
			else
			{
				array.SortStatus = false;
			}

			arrayRepository.Create(array);
		}

		static List <int> GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(-100, 101));
            }

            return numbers;
        }
        [TestMethod]
        public void TestMethod1()
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            int size;

            for(int i = 0; i < 100; i++)
            {
                size = random.Next(5, 10);
                numbers = GenerateRandomNumbers(size);
                SendArrays(numbers);
			}
        }
        [TestMethod]
        public void TestMethod2()
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            int size;

            for (int i = 0; i < 1000; i++)
            {
                size = random.Next(5, 10);
                numbers = GenerateRandomNumbers(size);
				SendArrays(numbers);
			}
        }

        [TestMethod]
        public void TestMethod3()
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            int size;

            for (int i = 0; i < 10000; i++)
            {
                size = random.Next(5, 10);
                numbers = GenerateRandomNumbers(size);
				SendArrays(numbers);
			}
        }
    }
}