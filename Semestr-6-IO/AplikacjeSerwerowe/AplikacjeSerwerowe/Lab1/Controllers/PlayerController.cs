using Lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Lab1.Controllers
{
    public class PlayerController : Controller
    {
        private readonly MyDbContext _db;

        public PlayerController(MyDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var players = _db.Players!.ToList();
            return View(players);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            /*var player = _db.Players!.Where(x => x.Id == id)
                .Include(p => p.Positions)
                .FirstOrDefault();*/
            var player = _db.Players!.FirstOrDefault(p => p.Id == id);
            var teams = _db.Teams!.ToList();
            var teamList = new List<SelectListItem>();
            teamList.Add(new SelectListItem("Brak", null));
            foreach (var team in teams)
            {
                var text = team.Name;
                var tid = team.Id.ToString();
                teamList.Add(new SelectListItem(text, tid));
            }
            ViewBag.teamList = teamList;

            var positions = _db.Positions!.ToList();
            var positionsList = new List<SelectListItem>();
            foreach (var position in positions)
            {
                var text = position.Name;
                var pid = position.Id.ToString();
                var selected = player != null && player.Positions.Any(x => x.Id == position.Id);
                positionsList.Add(new SelectListItem(text, pid, selected));
            }
            ViewBag.positionsList = positionsList;

            if (player == null)
            {
                @ViewBag.Header = "Dodaj gracza";
                @ViewBag.ButtonText = "Dodaj";
                return View();
            }

            @ViewBag.Header = "Edytuj gracza";
            @ViewBag.ButtonText = "Edytuj";
            return View(player);
 
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Player player, List<int> positions)
        {
            if(player.Id != 0)
            {
                /* var p = _db.Players!
                     .Where(x => x.Id == player.Id)
                     .Include(p => p.Positions)
                     .FirstOrDefault();*/
                var p = _db.Players!.FirstOrDefault(p => p.Id == player.Id);
                if (p != null)
                {
                    p.FirstName = player.FirstName;
                    p.LastName = player.LastName;
                    p.Country = player.Country;
                    p.BirthDate = player.BirthDate;
                    if (player.TeamId != null)
                    {
                        var team = _db.Teams!.FirstOrDefault(t => t.Id == player.TeamId);
                        p.Team = team!;
                    }
                    else
                    {
                        p.TeamId = player.TeamId;
                        p.Team = null;
                    }
                    p.Positions.Clear();
                    p.Positions = _db.Positions!.Where(p => positions.Contains(p.Id)).ToList();
                }
            }
            else
            {
                player.Positions = _db.Positions!.Where(p => positions.Contains(p.Id)).ToList();
                _db.Players!.Add(player);
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
            var player = _db.Players!.FirstOrDefault(x => x.Id == id);
            if (player == null)
            {
                return NotFound();
            }
            return View(player);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var player = _db.Players!
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
                _db.Players!.Remove(player!);
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
