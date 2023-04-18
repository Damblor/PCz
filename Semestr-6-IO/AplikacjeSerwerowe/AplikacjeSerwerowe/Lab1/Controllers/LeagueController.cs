using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class LeagueController : Controller
    {
        private readonly MyDbContext _db;

        public LeagueController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var leagues = _db.Leagues!.ToList();
            return View(leagues);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            if (id != -1)
            {
                var league = _db.Leagues!
                    .FirstOrDefault(l => l.Id == id);
                @ViewBag.Header = "Edytuj lige";
                @ViewBag.ButtonText = "Edytuj";
                return View(league);
            }
            else
            {
                @ViewBag.Header = "Dodaj lige";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(League league)
        {
            if (league.Id != 0)
            {
                var l = _db.Leagues!.FirstOrDefault(l => l.Id == league.Id);
                if (l != null)
                {
                    l.Name = league.Name;
                    l.Country = league.Country;
                    l.Level = league.Level;
                }
            }
            else
            {
                _db.Leagues!.Add(league);
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

            var league = _db.Leagues!
                .FirstOrDefault(l => l.Id == id);
            if (league == null)
            {
                return NotFound();
            }

            return View(league);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var league = _db.Leagues!.Where(l => l.Id == id)
                    //.Include(a => a.Articles)
                    .FirstOrDefault();
                _db.Leagues!.Remove(league!);
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
