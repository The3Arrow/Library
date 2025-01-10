using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class CategoryController : Controller
    {
        private readonly BooksDbContext _context;
        public CategoryController(BooksDbContext context)
        {
            _context = context;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            var Copies = _context.Category.ToList();
            return View(Copies);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            var categories = _context.Category.ToList();
            // Utwórz SelectList i przekaż ją do ViewBag
            ViewBag.BookId = new SelectList(categories, "Id", "Title");
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category updatedCategory)
        {
            try
            {
                Category category = new Category();
                category.Name = updatedCategory.Name;
                _context.Category.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedCategory);
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Category
            .FirstOrDefault(b => b.Id == id);
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,  Category updatedCategory)
        {
            var category = _context.Category
            .FirstOrDefault(b => b.Id == id);

            category.Name = updatedCategory.Name;


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
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
