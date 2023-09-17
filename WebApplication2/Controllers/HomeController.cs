using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
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

        [HttpPost]
        public IActionResult HandleButtonClick()
        {
            // Выполните необходимую логику обработки нажатия кнопки здесь
            // Этот метод будет вызван при отправке запроса с клиента

            return Ok(); // Верните успешный результат
        }


        public IDbConnection connection
        {
            get { return new SqlConnection(_configuration.GetConnectionString("DefaultConnection")); }
        }

        private List<Models.User> GetUsers()    
        {
            using (IDbConnection db = connection)
            {
                List<Models.User> users = db.Query<Models.User>("SELECT * FROM Users").ToList();

                return users;
            }

        }

        

        public IActionResult Index()
        {
            var items = GetUsers();
            return View(items);
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
    }
}