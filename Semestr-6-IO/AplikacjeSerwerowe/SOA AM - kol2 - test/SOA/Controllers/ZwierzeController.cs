using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.ViewModels;

namespace Web.Controllers
{
	public class ZwierzeController : BaseController
	{
		private readonly IZwierzeService _zwierzeService;
		public ZwierzeController(IZwierzeService zwierzeService, IMapper mapper) : base(mapper)
		{
			_zwierzeService = zwierzeService;
		}

        [HttpGet]
        public IActionResult Index()
		{
			var zwierzeta = _zwierzeService.GetAll();
			return View(zwierzeta);
		}

        [HttpGet]
        public IActionResult Info(int id)
		{
			var zwierze = _zwierzeService.GetZwierze(id);
			return View(zwierze);
		}

		[HttpGet]
		public IActionResult AddOrUpdate(int id)
		{
			if (id == 0)
			{
                ViewBag.Header = "Dodaj";
                ViewBag.Button = "Dodaj";
                return View();
			}
			else
			{
				ViewBag.Header = "Update";
				ViewBag.Button = "Update";
				var zwierze = _zwierzeService.GetAddOrUpdateZwierze(id);
				return View(zwierze);
			}
		}

		[HttpPost]
		public IActionResult AddOrUpdate(AddOrUpdateZwierzeVM addOrUpdateZwierzeVM)
		{
			if(ModelState.IsValid)
			{
				_zwierzeService.AddOrUpdate(addOrUpdateZwierzeVM);
				return RedirectToAction("Index");
			}
			return View();
		}

        [HttpGet]
        public IActionResult Delete(int id)
		{
			_zwierzeService.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
