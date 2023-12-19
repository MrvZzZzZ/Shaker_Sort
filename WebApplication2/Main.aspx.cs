using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class Main : System.Web.UI.Page
    {
        private SqlConnection _sqlConnection = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            _sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"DataBase1"].ConnectionString);

            _sqlConnection.Open();

            if (!IsPostBack)
            {
                string query = "SELECT * FROM Numbers";
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[@"DataBase1"].ConnectionString);
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();

                connection.Open();

                IncreaseDataBase(connection, query);

                adapter.Fill(dataTable);
                connection.Close();
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
        }

        private void IncreaseDataBase(SqlConnection connection, string query)
        {
            for (int i = 1; i <= 2; i++)
            {
                string numbers = GenerateNumbers();
                bool sortStatus = false;
                query = "INSERT INTO Numbers (SortStatus, Numbers) VALUES (@sortStatus, @numbers)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SortStatus", sortStatus);
                    command.Parameters.AddWithValue("@Numbers", numbers);

                    command.ExecuteNonQuery();
                }
            }
        }

        private string GenerateNumbers()
        {
            Random random = new Random();
            string numbers = "";

            for (int i = 0; i < random.Next(5, 20); i++)
            {
                numbers += random.Next(-100, 101) + " ";
            }

            //numbers = numbers.TrimEnd(',');
            return numbers;
        }
    }
}