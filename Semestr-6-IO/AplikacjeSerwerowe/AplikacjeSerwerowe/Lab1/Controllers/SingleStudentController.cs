using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class SingleStudentController : Controller
    {
        public IActionResult Index(Student student)
        {
            return View(student);
        }
    }
}
