using Microsoft.AspNetCore.Mvc;

namespace SOA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
