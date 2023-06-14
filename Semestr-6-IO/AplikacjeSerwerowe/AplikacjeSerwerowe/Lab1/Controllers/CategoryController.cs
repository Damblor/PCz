using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly MyDbContext _db;

        public CategoryController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var categories = _db.Categories!.ToList();
            return View(categories);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            if (id != -1)
            {
                var category = _db.Categories!
                    .FirstOrDefault(c => c.Id == id);
                @ViewBag.Header = "Edytuj kategorie";
                @ViewBag.ButtonText = "Edytuj";
                return View(category);
            }
            else
            {
                @ViewBag.Header = "Dodaj kategorie";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Category category)
        {
            if (category.Id != 0)
            {
                var c = _db.Categories!.FirstOrDefault(c => c.Id == category.Id);
                if (c != null)
                {
                    c.Name = category.Name;
                }
            }
            else
            {
                _db.Categories!.Add(category);
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

            var category = _db.Categories!
                .FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _db.Categories!.Where(c => c.Id == id)
                    //.Include(a => a.Articles)
                    .FirstOrDefault();
                _db.Categories!.Remove(category!);
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
