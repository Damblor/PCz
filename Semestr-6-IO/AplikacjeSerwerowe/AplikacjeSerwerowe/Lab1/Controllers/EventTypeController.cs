using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
	public class EventTypeController : Controller
	{
		private readonly MyDbContext _db;

		public EventTypeController(MyDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			var eventTypes = _db.EventTypes!.ToList();
			return View(eventTypes);
		}

		public IActionResult AddOrUpdate(int id = -1)
		{
			if (id != -1)
			{
				var eventTypes = _db.EventTypes!
					.FirstOrDefault(e => e.Id == id);
				@ViewBag.Header = "Edytuj typ eventu";
				@ViewBag.ButtonText = "Edytuj";
				return View(eventTypes);
			}
			else
			{
				@ViewBag.Header = "Dodaj typ eventu";
				@ViewBag.ButtonText = "Dodaj";
				return View();
			}
		}

		[HttpPost]
		public IActionResult AddOrUpdate(EventType eventTypes)
		{
			if (eventTypes.Id != 0)
			{
				var e = _db.EventTypes!.FirstOrDefault(e => e.Id == eventTypes.Id);
				if (e != null)
				{
					e.Name = eventTypes.Name;
				}
			}
			else
			{
				_db.EventTypes!.Add(eventTypes);
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

			var eventTypes = _db.EventTypes!
				.FirstOrDefault(e => e.Id == id);
			if (eventTypes == null)
			{
				return NotFound();
			}

			return View(eventTypes);
		}

		[HttpPost]
		public IActionResult Delete(int id)
		{
			try
			{
				var eventTypes = _db.EventTypes!.Where(a => a.Id == id)
					//.Include(a => a.Articles)
					.FirstOrDefault();
				_db.EventTypes!.Remove(eventTypes!);
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
