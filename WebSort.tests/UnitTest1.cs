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

            for (int i = 0; i < count; i++)
            {
                int size = _random.Next(5, 10);
                List<int> numbers = GenerateRandomNumbers(size);
                SendArrays(numbers);
            }
        }

        public void StartSortArrays(int count)
        {
            List<Array> arrays = _arrayRepository.GetArrays();

            for (int i = 0; i < count; i++)
            {
                List<int> numbers = arrays[i].Numbers.Split(' ').Select(int.Parse).ToList();
                _shakerSort = new ShakerSort(numbers);
                numbers = _shakerSort.RunShakerSort();
            }
        }

        public void StartDeleteArrays()
        {
            using (IDbConnection db = new SqlConnection("Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False"))
            {
                var sqlQuery = "DELETE FROM Numbers";
                db.Execute(sqlQuery);
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
            int count = 100;
            StartSortArrays(count);
        }

        [TestMethod]
        public void ESortSecondTest()
        {
            int count = 1000;
            StartSortArrays(count);
        }

        [TestMethod]
        public void HSortThirdTest()
        {
            int count = 10000;
            StartSortArrays(count);
        }

        [TestMethod]
        public void ÑClearDataBase()
        {
            StartDeleteArrays();
        }

        [TestMethod]
        public void FClearDataBase()
        {
            StartDeleteArrays();
        }

        [TestMethod]
        public void IClearDataBase()
        {
            StartDeleteArrays();
        }
    }
}