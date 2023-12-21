using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebSort.Models;
using Dapper;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace WebSort.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IDbConnection CreateConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var model = GetNumbers();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Array> GetNumbers()
        {
            using (IDbConnection db = CreateConnection)
            {
                var result = db.Query<Array>("SELECT * FROM Numbers").ToList();

                return result;
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

    public class Array
    {
        public int Id { get; set; }
        public bool SortStatus { get; set; }
        public string? Numbers { get; set; }
    }
}
