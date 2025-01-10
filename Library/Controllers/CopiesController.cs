using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class CopiesController : Controller
    {
        private readonly BooksDbContext _context;
        public CopiesController(BooksDbContext context)
        {
            _context = context;
        }
        // GET: CopiesController
        public ActionResult Index()
        {
            var Copies = _context.Copies.OrderBy(c => c.BookId).Include(C => C.Client).Include(b => b.Book).ToList();
            return View(Copies);
        }

        // GET: CopiesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CopiesController/Create
        public ActionResult Create()
        {
            var books = _context.Books.ToList();
            // Utwórz SelectList i przekaż ją do ViewBag
            ViewBag.BookId = new SelectList(books, "Id", "Title");
            return View();
        }

        // POST: CopiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Copies updatedCopy)
        {
            try
            {
                Copies copy = new Copies();
                copy.BookId = updatedCopy.BookId;
                copy.IsAvailable = true;
                copy.ClientId = 1;
                _context.Copies.Add(copy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var books = _context.Books.ToList();
                // Utwórz SelectList i przekaż ją do ViewBag
                ViewBag.BookId = new SelectList(books, "Id", "Title");
                return View(updatedCopy);
            }
        }

        // GET: CopiesController/Edit/5
        public ActionResult Edit(int id)
        {
            var copy = _context.Copies
            .FirstOrDefault(b => b.CopyId == id);

            var books = _context.Books.ToList();
            ViewBag.BookId = new SelectList(books, "Id", "Title");
            var clients = _context.Clients.ToList();
            ViewBag.ClientId = new SelectList(clients, "ClientId", "FirstName");

            return View(copy);
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Copies updatedCopy)
        {


            var books = _context.Books.ToList();
            ViewBag.BookId = new SelectList(books, "Id", "Title");
            var clients = _context.Clients.ToList();
            ViewBag.ClientId = new SelectList(clients, "ClientId", "FirstName");

            var copy = _context.Copies
            .FirstOrDefault(b => b.CopyId == id);

            copy.BookId = updatedCopy.BookId;
            copy.IsAvailable = updatedCopy.IsAvailable;
            if(!updatedCopy.IsAvailable)
                copy.ClientId = updatedCopy.ClientId;
            else
                copy.ClientId = 1;


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        // GET: CopiesController/Delete/5
        public ActionResult Delete(int id)
        {
            var book = _context.Copies
            .FirstOrDefault(b => b.CopyId == id);
            return View(book);
        }

        // POST: CopiesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var copy = _context.Copies
                .FirstOrDefault(b => b.CopyId == id);
                _context.Copies.Remove(copy);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
