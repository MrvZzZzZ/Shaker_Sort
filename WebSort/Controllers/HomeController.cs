using Dapper;
using DevExpress.Data.Browsing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using WebSort.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.IdentityModel.Tokens;

namespace WebSort.Controllers
{
    public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;
		private readonly IArrayRepository _repository;
		private Utils utils = new Utils();

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

		public ActionResult Details(int id)
		{
			Array array = _repository.Get(id);
			if (array != null)
				return View(array);
			return NotFound();
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(Array array)
		{
			if (array.Numbers == null)
			{
				return NotFound();
			}

			if (utils.IsSorted(array.Numbers.Split(' ').Select(Int32.Parse).ToList()) == false)
			{
				array.SortStatus = false;
			}
			else
			{
				array.SortStatus = true;
            }

            _repository.Create(array);
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
            if (utils.IsSorted(array.Numbers.Split(' ').Select(Int32.Parse).ToList()) == false)
            {
                array.SortStatus = false;
            }
            else
            {
                array.SortStatus = true;
            }

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

		[HttpPost]
		public ActionResult Sort(int id)
		{
			_repository.Sort(id);
			return RedirectToAction("Privacy");
		}
	}
}
