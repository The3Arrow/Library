using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class ClientsController : Controller
    {
        private readonly BooksDbContext _context;
        public ClientsController(BooksDbContext context)
        {
            _context = context;
        }
        // GET: ClientsController
        public ActionResult Index()
        {
            var Clients = _context.Clients.ToList();
            return View(Clients);
        }

        // GET: ClientsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clients updatedClient)
        {
            try
            {
                Clients client = new Clients();
                client.FirstName = updatedClient.FirstName;
                client.Surname = updatedClient.Surname;

                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(updatedClient);
            }
        }

        // GET: ClientsController/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _context.Clients
            .FirstOrDefault(b => b.ClientId == id);
            return View(client);
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Clients updatedClient)
        {
            var client = _context.Clients
            .FirstOrDefault(b => b.ClientId == id);

            client.FirstName = updatedClient.FirstName;
            client.Surname = updatedClient.Surname;


            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: ClientsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClientsController/Delete/5
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
