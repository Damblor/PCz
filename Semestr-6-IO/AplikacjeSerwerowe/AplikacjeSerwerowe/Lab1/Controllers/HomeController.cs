using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDbContext _db;

        public HomeController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
    }
}
