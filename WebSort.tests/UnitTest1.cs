using Dapper;
using Microsoft.Data.SqlClient;
using Shaker;
using System;
using System.Data;
using WebSort.Controllers;

namespace WebSort.tests
{
    [TestClass]
    public class UnitTest1
    {
        private ShakerSort? _shakerSort;
        private Utils _utils = new Utils();
        private ArrayRepository _arrayRepository = new ArrayRepository("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False");
        private Array _array = new Array();
        private Random _random = new Random();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="numbers"></param>
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

        public List<int> GenerateRandomNumbers(int count)
        {
            Random random = new Random();
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                numbers.Add(random.Next(-100, 101));
            }

            return numbers;
        }

        public void GenerateArraysForTests(int count)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < count; i++)
            {
                int size = _random.Next(5, 10);
                numbers = GenerateRandomNumbers(size);
                SendArrays(numbers);
            }
        }

        [TestMethod]
        public void ATestMethodOneHoundredItems()
        {
            int count = 100;
            GenerateArraysForTests(count);
        }

        [TestMethod]
        public void DTestMethodOneThousandItems()
        {
            int count = 1000;
            GenerateArraysForTests(count);
        }

        [TestMethod]
        public void GTestMethodTenThousandItems()
        {
            int count = 10000;
            GenerateArraysForTests(count);
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
        public void ESortSecondTest()
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
        public void HSortThirdTest()
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
        public void ÑClearDataBase()
        {
            using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"))
            {
                var sqlQuery = "DELETE FROM Numbers";
                db.Execute(sqlQuery);
            }
        }

        [TestMethod]
        public void FClearDataBase()
        {
            using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"))
            {
                var sqlQuery = "DELETE FROM Numbers";
                db.Execute(sqlQuery);
            }
        }

        [TestMethod]
        public void IClearDataBase()
        {
            using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"))
            {
                var sqlQuery = "DELETE FROM Numbers";
                db.Execute(sqlQuery);
            }
        }
    }
}