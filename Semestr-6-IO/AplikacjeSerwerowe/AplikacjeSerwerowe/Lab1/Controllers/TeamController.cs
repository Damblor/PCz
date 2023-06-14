using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab1.Controllers
{
    public class TeamController : Controller
    {
        private readonly MyDbContext _db;

        public TeamController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var teams = _db.Teams!.ToList();
            return View(teams);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            var leagues = _db.Leagues!.ToList();
            var leaguesList = new List<SelectListItem>();
            foreach (var league in leagues)
            {
                string text = league.Name;
                string lid = league.Id.ToString();
                leaguesList.Add(new SelectListItem(text, lid));
            }
            ViewBag.Leagues = leaguesList;
            if (id != -1)
            {
                var team = _db.Teams!
                    .FirstOrDefault(t => t.Id == id);
                @ViewBag.Header = "Edytuj drużynę";
                @ViewBag.ButtonText = "Edytuj";
                return View(team);
            }
            else
            {
                @ViewBag.Header = "Dodaj drużynę";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Team team)
        {
            if (team.Id != 0)
            {
                var t = _db.Teams!.FirstOrDefault(t => t.Id == team.Id);
                if (t != null)
                {
                    t.Name = team.Name;
                    t.Country = team.Country;
                    t.City = team.City;
                    t.FoundingDate = team.FoundingDate;
                    var league = _db.Leagues!.FirstOrDefault(l => l.Id == team.LeagueId);
                    t.League = league!;
                }
            }
            else
            {
                _db.Teams!.Add(team);
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

			var team = _db.Teams!
				.FirstOrDefault(t => t.Id == id);
			if (team == null)
			{
				return NotFound();
			}

			return View(team);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var team = _db.Teams!.Where(t => t.Id == id)
					//.Include(a => a.Articles)
					.FirstOrDefault();
				_db.Teams!.Remove(team!);
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
