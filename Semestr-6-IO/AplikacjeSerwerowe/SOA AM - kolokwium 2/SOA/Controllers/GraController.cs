using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels.ViewModels;

namespace Web.Controllers
{
	public class GraController : BaseController
	{
		private readonly IGraService _graService;
		public GraController(IGraService graService, IMapper mapper) : base(mapper)
		{
			_graService = graService;
		}

		public IActionResult Index()
		{
			var gry = _graService.GetAll();
			return View(gry);
		}

		[HttpGet]
		public IActionResult AddOrUpdate(int id)
		{
			if (id == 0)
			{
				ViewBag.Header = "Dodawanie";
				ViewBag.Button = "Dodaj";
                return View();
			}
			else
			{
                ViewBag.Header = "Edytowanie";
                ViewBag.Button = "Edytuj";
                var gra = _graService.GetAddOrUpdateVM(id);
				return View(gra);
			}
		}

		[HttpPost]
        public IActionResult AddOrUpdate(AddOrUpdateGraVM addOrUpdateGraVM)
        {
			if(ModelState.IsValid)
			{
				_graService.AddOrUpdate(addOrUpdateGraVM);
				return RedirectToAction("Index");
			}
			return View();
        }

		public IActionResult Delete(int id)
		{
			_graService.Delete(id);
			return RedirectToAction("Index");
		}
    }
}
