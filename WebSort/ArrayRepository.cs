using Dapper;
using Microsoft.Data.SqlClient;
using Shaker;
using System.Data;
using WebSort.Controllers;

namespace WebSort
{
    /// <summary>
    /// Интерфейс взаимодействия 
    /// </summary>
    public interface IArrayRepository
    {
        void Create(Array array);
        void Delete(int id);
        Array Get(int id);
        List<Array> GetArrays();
        void Update(Array array);
        void Sort(int id);
    }

    /// <summary>
    /// Методы взаимодействия с базой данных с помощью запросов
    /// </summary>
    public class ArrayRepository : IArrayRepository
    {
        private string? _connectionString = null;

        public ArrayRepository(string connection)
        {
            _connectionString = connection;
        }

        /// <summary>
        /// Добавление поля в базу
        /// </summary>
        /// <param name="array">Добавляемый экземпляр</param>
        public void Create(Array array)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO Numbers (SortStatus, Numbers) VALUES(@SortStatus, @Numbers)";
                db.Execute(sqlQuery, array);
            }
        }

        /// <summary>
        /// Удаление поля из базы
        /// </summary>
        /// <param name="id">id удаляемого поля</param>
        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "DELETE FROM Numbers WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        /// <summary>
        /// Получение поля по id
        /// </summary>
        /// <param name="id">id поля</param>
        /// <returns>Экземпляр найденный по id</returns>
        public Array Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Array>("SELECT * FROM Numbers WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        /// <summary>
        /// Получение Списка всех полей базы
        /// </summary>
        /// <returns>Список полей</returns>
        public List<Array> GetArrays()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var result = db.Query<Array>("SELECT * FROM Numbers").ToList();

                return result;
            }
        }

        /// <summary>
        /// Сортировка выбранного массива
        /// </summary>
        /// <param name="id">id поля</param>
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

        /// <summary>
        /// Изменение поля в базе
        /// </summary>
        /// <param name="array">Изменяемый экземпляр</param>
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
