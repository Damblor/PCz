using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class PositionController : Controller
    {
        private readonly MyDbContext _db;

        public PositionController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var positions = _db.Positions!.ToList();
            return View(positions);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            if (id != -1)
            {
                var position = _db.Positions!
                    .FirstOrDefault(p => p.Id == id);
                @ViewBag.Header = "Edytuj pozycje";
                @ViewBag.ButtonText = "Edytuj";
                return View(position);
            }
            else
            {
                @ViewBag.Header = "Dodaj pozycje";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Position position)
        {
            if (position.Id != 0)
            {
                var p = _db.Positions!.FirstOrDefault(p => p.Id == position.Id);
                if (p != null)
                {
                    p.Name = position.Name;
                }
            }
            else
            {
                _db.Positions!.Add(position);
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

            var position = _db.Positions!
                .FirstOrDefault(p => p.Id == id);
            if (position == null)
            {
                return NotFound();
            }

            return View(position);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var position = _db.Positions!.Where(p => p.Id == id)
                    //.Include(a => a.Articles)
                    .FirstOrDefault();
                _db.Positions!.Remove(position!);
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
