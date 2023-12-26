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
        private readonly Utils _utils;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IArrayRepository repository)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = repository;
            _utils = new Utils();
        }
        /// <summary>
        /// ���������� ������������� � ������� �� �����������
        /// </summary>
        /// <returns>�������</returns>
        public IActionResult Index()
        {
            return View(_repository.GetArrays());
        }

        /// <summary>
        /// ���������� ������������� � ������� �� �����������
        /// </summary>
        /// <returns>�������</returns>
        public IActionResult Privacy()
        {
            return View(_repository.GetArrays());
        }

        /// <summary>
        /// ���������� ������������� � ������� �� ������ ������ � ������ ������������� ������
        /// </summary>
        /// <returns>������ ������</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// ��������� �������������, �������� ������ �� �������������� � ���������� ��������������� �������������
        /// </summary>
        /// <param name="id"></param>
        /// <returns>������������� � ����������� �� ���������� �������</returns>
        public ActionResult Details(int id)
        {
            Array array = _repository.Get(id);
            if (array != null)
                return View(array);
            return NotFound();
        }

        /// <summary>
        /// ���������� ������������� ��� �������� ������ �������
        /// </summary>
        /// <returns>�������������</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// �������� ������� ����� ������, ������������� �������� ���� ������������.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>�������������</returns>
        [HttpPost]
        public ActionResult Create(Array array)
        {
            while (String.IsNullOrEmpty(array.Numbers))
            {
                return View();
            }

            if (_utils.ContainsLetters(array.Numbers))
            {
                return View();
            }

            if (_utils.IsSorted(array.Numbers.Split(' ').Select(Int32.Parse).ToList()) == false)
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

        /// <summary>
        /// ��������� �������������, �������� ������ �� �������������� � ���������� ��������������� ������������� 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>�������������</returns>
        public ActionResult Edit(int id)
        {
            Array array = _repository.Get(id);
            if (array != null)
                return View(array);
            return NotFound();
        }

        /// <summary>
        /// �������� �������� ������, ������������� �������� ���� ������������
        /// </summary>
        /// <param name="array"></param>
        /// <returns>������������</returns>
        [HttpPost]
        public ActionResult Edit(Array array)
        {
            while (String.IsNullOrEmpty(array.Numbers))
            {
                return View();
            }

            if (_utils.ContainsLetters(array.Numbers))
            {
                return View();
            }

            if (_utils.IsSorted(array.Numbers.Split(' ').Select(Int32.Parse).ToList()) == false)
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

        /// <summary>
        /// ���������� ������������� ��� ������������� �������� �������
        /// </summary>
        /// <param name="id"></param>
        /// <returns>�������������</returns>
        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            Array array = _repository.Get(id);
            if (array != null)
                return View(array);
            return NotFound();
        }

        /// <summary>
        /// ������� ������ �� ���������� ��������������
        /// </summary>
        /// <param name="id"></param>
        /// <returns>�������������</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Privacy");
        }

        /// <summary>
        /// ��������� ������ �� ���������� ��������������
        /// </summary>
        /// <param name="id"></param>
        /// <returns>������������</returns>
        [HttpPost]
        public ActionResult Sort(int id)
        {
            _repository.Sort(id);
            return RedirectToAction("Privacy");
        }

        /// <summary>
        /// ��������� ������� ����������� � ���� ������ � ������� ������ ����������� �� ������������
        /// </summary>
        public IDbConnection CreateConnection
        {
            get
            {
                return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            }
        }
    }
}
