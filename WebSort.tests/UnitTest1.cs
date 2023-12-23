using Dapper;
using Microsoft.Data.SqlClient;
using Shaker;
using System.Data;
using WebSort;
using WebSort.Controllers;

namespace WebSort.tests
{
    [TestClass]
    public class UnitTest1
    {
        private ShakerSort? _shakerSort;
		private	Utils _utils = new Utils();
		private	ArrayRepository _arrayRepository = new ArrayRepository("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False");
		private Array _array = new Array();

		private void SendArrays(List<int> numbers)
		{
			_array.Numbers = _utils.ConvertIntListToString(numbers);

			if (_utils.IsSorted(numbers))
			{
				_array.SortStatus = true;
			}
			else
			{
				_array.SortStatus = false;
			}

			_arrayRepository.Create(_array);
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
        public void ATestMethodOneHoundredItems()
        {
            List<int> numbers = new List<int>();
            Random random = new Random();
            int size;

            for (int i = 0; i < 100; i++)
            {
                size = random.Next(5, 10);
                numbers = GenerateRandomNumbers(size);
                SendArrays(numbers);
            }
        }

		[TestMethod]
        public void CTestMethodOneThousandItems()
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
        public void ETestMethodTenThousandItems()
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

		[TestMethod]
		public void BSortFirstTest()
		{
			List<Array> arrays = _arrayRepository.GetArrays();

			for (int i = 0; i < 100; i++)
			{
				List<int> numbers = arrays[i].Numbers.Split(' ').Select(int.Parse).ToList();
				_shakerSort = new ShakerSort(numbers);
				numbers = _shakerSort.RunShakerSort();
			}
		}

		[TestMethod]
		public void DSortSecondTest()
		{
			List<Array> arrays = _arrayRepository.GetArrays();

			for (int i = 0; i < 1000; i++)
			{
				List<int> numbers = arrays[i].Numbers.Split(' ').Select(int.Parse).ToList();
				_shakerSort = new ShakerSort(numbers);
				numbers = _shakerSort.RunShakerSort();
			}
		}

		[TestMethod]
		public void FSortThirdTest()
		{
			List<Array> arrays = _arrayRepository.GetArrays();

			for (int i = 0; i < 10000; i++)
			{
				List<int> numbers = arrays[i].Numbers.Split(' ').Select(int.Parse).ToList();
				_shakerSort = new ShakerSort(numbers);
				numbers = _shakerSort.RunShakerSort();
			}
		}

		[TestMethod]
		public void GClearDataBase()
		{
			using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"))
			{
				var sqlQuery = "DELETE FROM Numbers";
				db.Execute(sqlQuery);
			}
		}
	}
}