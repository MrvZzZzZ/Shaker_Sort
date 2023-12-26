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
        /// ¬озвращает представление с данными из репозитори€
        /// </summary>
        /// <returns>ћассивы</returns>
        public IActionResult Index()
        {
            return View(_repository.GetArrays());
        }

        /// <summary>
        /// ¬озвращает представление с данными из репозитори€
        /// </summary>
        /// <returns>ћассивы</returns>
        public IActionResult Privacy()
        {
            return View(_repository.GetArrays());
        }

        /// <summary>
        /// ¬озвращает представление с данными из модели ошибки в случае возникновени€ ошибки
        /// </summary>
        /// <returns>модели ошибки</returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// принимает идентификатор, получает массив по идентификатору и возвращает соответствующее представление
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ѕредставление в зависимости от содержани€ массива</returns>
        public ActionResult Details(int id)
        {
            Array array = _repository.Get(id);
            if (array != null)
                return View(array);
            return NotFound();
        }

        /// <summary>
        /// возвращает представление дл€ создани€ нового массива
        /// </summary>
        /// <returns>представление</returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// пытаетс€ создать новый массив, дополнительно провер€€ ввод пользовател€.
        /// </summary>
        /// <param name="array"></param>
        /// <returns>ѕредставление</returns>
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
        /// принимает идентификатор, получает массив по идентификатору и возвращает соответствующее представление 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ѕредставление</returns>
        public ActionResult Edit(int id)
        {
            Array array = _repository.Get(id);
            if (array != null)
                return View(array);
            return NotFound();
        }

        /// <summary>
        /// пытаетс€ обновить массив, дополнительно провер€€ ввод пользовател€
        /// </summary>
        /// <param name="array"></param>
        /// <returns>ѕредставлние</returns>
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
        /// возвращает представление дл€ подтверждени€ удалени€ массива
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ѕредставление</returns>
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
        /// удал€ет массив по указанному идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ѕредставление</returns>
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Privacy");
        }

        /// <summary>
        /// сортирует массив по указанному идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ѕредставлние</returns>
        [HttpPost]
        public ActionResult Sort(int id)
        {
            _repository.Sort(id);
            return RedirectToAction("Privacy");
        }

        /// <summary>
        /// получение объекта подключени€ к базе данных с помощью строки подключени€ из конфигурации
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
