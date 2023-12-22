using Dapper;
using DevExpress.Data.Browsing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using WebSort.Models;

namespace WebSort.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;
		private readonly IArrayRepository _repository;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IArrayRepository repository)
		{
			_logger = logger;
			_configuration = configuration;
			_repository = repository;
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
			return View(_repository.GetArrays());
		}

		public IActionResult Privacy()
		{
			return View(_repository.GetArrays());
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

		public ActionResult Details(int id)
		{
			Array user = _repository.Get(id);
			if (user != null)
				return View(user);
			return NotFound();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Array user)
		{
			_repository.Create(user);
			return RedirectToAction("Privacy");
		}

		public ActionResult Edit(int id)
		{
			Array array = _repository.Get(id);
			if (array != null)
				return View(array);
			return NotFound();
		}

		[HttpPost]
		public ActionResult Edit(Array array)
		{
			_repository.Update(array);
			return RedirectToAction("Privacy");
		}

		[HttpGet]
		[ActionName("Delete")]
		public ActionResult ConfirmDelete(int id)
		{
			Array array = _repository.Get(id);
			if (array != null)
				return View(array);
			return NotFound();
		}
		[HttpPost]
		public ActionResult Delete(int id)
		{
			_repository.Delete(id);
			return RedirectToAction("Privacy");
		}
	}
}
