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
            var model = GetNumbers();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
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
    }

    public class Array
    {
        public int Id { get; set; }
        public bool SortStatus { get; set; }
        public string? Numbers { get; set; }
    }
}
