using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using Shaker;
using WebSort.Controllers;

namespace WebSort
{
    public interface IArrayRepository
    {
        void Create(Array array);
        void Delete(int id);
        Array Get(int id);
        List<Array> GetArrays();
        void Update(Array array);
        void Sort(int id);
    }
    public class ArrayRepository : IArrayRepository
    {
        private string? _connectionString = null;

        public ArrayRepository(string connection)
        {
            _connectionString = connection;
        }

        public void Create(Array array)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Numbers (SortStatus, Numbers) VALUES(@SortStatus, @Numbers)";
                db.Execute(sqlQuery, array);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Numbers WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public Array Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Array>("SELECT * FROM Numbers WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public List<Array> GetArrays()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = db.Query<Array>("SELECT * FROM Numbers").ToList();

                return result;
            }
        }

        public void Sort(int id)
        {
            ShakerSort shakerSort;
            Utils utils = new Utils();

            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var array = db.Query<Array>("SELECT * FROM Numbers WHERE Id = @id", new { id }).FirstOrDefault();
                shakerSort = new ShakerSort(array.Numbers.Split(' ').Select(int.Parse).ToList());
                array.Numbers = utils.ConvertIntListToString(shakerSort.RunShakerSort());
                array.SortStatus = true;
                var sqlQuery = "UPDATE Numbers SET SortStatus = @SortStatus, Numbers = @Numbers WHERE Id = @Id";
                db.Execute(sqlQuery, array);
            }
        }

        public void Update(Array array)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "UPDATE Numbers SET SortStatus = @SortStatus, Numbers = @Numbers WHERE Id = @Id";
                db.Execute(sqlQuery, array);
            }
        }
    }
}
