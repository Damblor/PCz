using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly MyDbContext _db;

        public AuthorController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var authors = _db.Authors!.ToList();
            return View(authors);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            if (id != -1)
            {
                var author = _db.Authors!
                    .FirstOrDefault(a => a.Id == id);
                @ViewBag.Header = "Edytuj autora";
                @ViewBag.ButtonText = "Edytuj";
                return View(author);
            }
            else
            {
                @ViewBag.Header = "Dodaj autora";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Author author)
        {
            if (author.Id != 0)
            {
                var a = _db.Authors!.FirstOrDefault(a => a.Id == author.Id);
                if (a != null)
                {
                    a.FirstName = author.FirstName;
                    a.LastName = author.LastName;
                }
            }
            else
            {
                _db.Authors!.Add(author);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var author = _db.Authors!
                .FirstOrDefault(a => a.Id == id);
            if (author == null)
            {
                return NotFound();
            }

            return View(author);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var author = _db.Authors!.Where(a => a.Id == id)
                    //.Include(a => a.Articles)
                    .FirstOrDefault();
                _db.Authors!.Remove(author!);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return RedirectToAction("Index");
        }
    }
}
