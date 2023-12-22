using Dapper;
using Microsoft.Data.SqlClient;
using NuGet.Protocol.Plugins;
using System.Data;

namespace WebSort.Data
{
    public class DataBase
    {
		private readonly IConfiguration _configuration;

        public DataBase(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public IDbConnection CreateConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Array> GetBd()
        {
			using IDbConnection db = CreateConnection;
			var result = db.Query<Array>("SELECT * FROM Numbers").ToList();

			return result;
		}

		public void AddNumbers(int[] numbers)
		{
			string? connectionString = _configuration.GetConnectionString("DefaultConnection"); // Замените на вашу строку подключения к базе данных

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				string sqlCommand = "INSERT INTO Numbers (SortStatus, Numbers) VALUES (@SortStatus, @Numbers)";
				connection.Open();

				using (SqlCommand command = new SqlCommand(sqlCommand, connection))
				{
					command.Parameters.AddWithValue("@SortStatus", "New"); // Установите желаемый статус сортировки
					command.Parameters.AddWithValue("@Numbers", string.Join(",", numbers)); // Преобразуйте массив в строку для хранения в базе данных

					command.ExecuteNonQuery();
				}
			}
		}

		public void Insert(string Numbers)
        {
            try
            {
				using IDbConnection db = CreateConnection;
				var result = db.Query<Array>("INSERT INTO Numbers (SortStatus, Numbers) VALUES (@SortStatus, @Numbers)");

				using (SqlConnection connection = new SqlConnection("DefaultConnection"))
				{
					string sqlCommand = "INSERT INTO Numbers (SortStatus, Numbers) VALUES (@SortStatus, @Numbers)";
					connection.Open();

					using (SqlCommand command = new SqlCommand(sqlCommand, connection))
					{
						command.Parameters.AddWithValue("@SortStatus", false); // Установите желаемый статус сортировки
						command.Parameters.AddWithValue("@Numbers", string.Join(" ", Numbers)); // Преобразуйте массив в строку для хранения в базе данных

						command.ExecuteNonQuery();
					}

					connection.Open();

				}
			}
			finally
			{ }

        }
    }
}
