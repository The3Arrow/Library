using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BooksController : Controller
    {
        private static IList<Books> books = new List<Books>
 {
new Books(){Id = 1, Title = "Film1"},
new Books(){Id = 2, Title = "Film2" },
new Books(){Id = 3, Title = "Film3" },
 };

        // GET: BooksController
        public ActionResult Index()
        {
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View(books.FirstOrDefault(x => x.Id == id));
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
