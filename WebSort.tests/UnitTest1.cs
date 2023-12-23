namespace WebSort.tests
{
    [TestClass]
    public class UnitTest1
    {
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
                size = random.Next(5, 21);
                numbers = GenerateRandomNumbers(size);
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
                size = random.Next(5, 21);
                numbers = GenerateRandomNumbers(size);
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
                size = random.Next(5, 21);
                numbers = GenerateRandomNumbers(size);
            }
        }
    }
}