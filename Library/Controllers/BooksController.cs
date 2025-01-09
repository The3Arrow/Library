using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private readonly BooksDbContext _context;
        public BooksController(BooksDbContext context)
        {
            _context = context;
        }


        // GET: BooksController
        public ActionResult Index()
        {
            var Books = _context.Books.Include(f => f.Category).ToList();
            return View(Books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            var book = _context.Books
                    .Include(b => b.Category)
                    .FirstOrDefault(b => b.Id == id);
            return View(book);
           //return View();
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            // Pobierz kategorie z bazy danych
            var kategorie = _context.Category.ToList();
            // Utwórz SelectList i przekaż ją do ViewBag
            ViewBag.CategoryId = new SelectList(kategorie, "Id", "Name");
            return View();

        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,EditionYear,Description,CategoryId")] Books book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var categories = _context.Category.ToList();
                ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
                return View(book);
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            var book = _context.Books
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Books updatedBook)
        {
            var book = _context.Books
            .Include(b => b.Category)
            .FirstOrDefault(b => b.Id == id);

            book.Title = updatedBook.Title;
            book.EditionYear = updatedBook.EditionYear;
            book.Description = updatedBook.Description;

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
