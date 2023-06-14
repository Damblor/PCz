using Microsoft.AspNetCore.Mvc;

namespace AS_k1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
