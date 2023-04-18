using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class TagController : Controller
    {
        private readonly MyDbContext _db;

        public TagController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var tags = _db.Tags!.ToList();
            return View(tags);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            if (id != -1)
            {
                var tag = _db.Tags!
                    .FirstOrDefault(t => t.Id == id);
                @ViewBag.Header = "Edytuj tag";
                @ViewBag.ButtonText = "Edytuj";
                return View(tag);
            }
            else
            {
                @ViewBag.Header = "Dodaj tag";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Tag tag)
        {
            if (tag.Id != 0)
            {
                var t = _db.Tags!.FirstOrDefault(t => t.Id == tag.Id);
                if (t != null)
                {
                    t.Name = tag.Name;
                }
            }
            else
            {
                _db.Tags!.Add(tag);
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

            var tag = _db.Tags!
                .FirstOrDefault(t => t.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var tag = _db.Tags!.Where(t => t.Id == id)
                    //.Include(a => a.Articles)
                    .FirstOrDefault();
                _db.Tags!.Remove(tag!);
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
