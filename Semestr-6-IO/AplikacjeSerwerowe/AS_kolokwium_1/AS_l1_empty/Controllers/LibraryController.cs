using AS_k1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AS_k1.Controllers
{
    public class LibraryController : Controller
    {
        private readonly MyDbContext _context;

        public LibraryController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var librarys = _context.Librarys!.ToList();
            return View(librarys);
        }

        public IActionResult AddOrUpdate(int id = -1)
        {
            var books = _context.Books!.ToList();
            var bookList = new List<SelectListItem>();
            foreach (var book in books)
            {
                var text = book.Tytul;
                var tid = book.Id.ToString();
                bookList.Add(new SelectListItem(text, tid));
            }
            ViewBag.bookList = bookList;

            if (id == -1)
            {
                ViewBag.Header = "Dodaj biblioteke";
                ViewBag.ButtonText = "Dodaj";
                return View();
            }
            else
            {
                var library = _context.Librarys!.FirstOrDefault(x => x.Id == id);
                ViewBag.Header = "Edytuj biblioteke";
                ViewBag.ButtonText = "Edytuj";
                return View(library);
            }
        }

        [HttpPost]
        public IActionResult AddOrUpdate(Library library, List<int> bookId)
        {
            var books = _context.Books!.Where(x => bookId.Contains(x.Id)).ToList();
            library.Books = books;
            _context.Librarys!.Add(library);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
