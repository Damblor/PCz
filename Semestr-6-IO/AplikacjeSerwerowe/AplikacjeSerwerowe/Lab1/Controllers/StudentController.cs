using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class StudentController : Controller
    {
        List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Jacek",
                Surname = "Kot",
                Index = 133123,
                BirthDate = new DateTime(2000, 7, 11),
                Faculty = "Informatyka"
            },
            new Student
            {
                Id = 2,
                Name = "Marianna",
                Surname = "Lak",
                Index = 147413,
                BirthDate = new DateTime(1997, 1, 23),
                Faculty = "Matematyka Stosowana"
            },
            new Student
            {
                Id = 3,
                Name = "Zbyszek",
                Surname = "Awdar",
                Index = 166246,
                BirthDate = new DateTime(2004, 11, 3),
                Faculty = "Mechanika"
            },
            new Student
            {
                Id = 4,
                Name = "Krzysztof",
                Surname = "Kowalski",
                Index = 123456,
                BirthDate = new DateTime(1999, 5, 5),
                Faculty = "Informatyka"
            },
        };

        public IActionResult Index()
        {
            
            return View(students);
        }

        public IActionResult Details(int id)
        {
            return View(students[id]);
        }
    }
}
