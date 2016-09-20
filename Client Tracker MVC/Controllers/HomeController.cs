using Client_Tracker_MVC.Models;
using System.Web.Mvc;
using System.Linq;
using System.Diagnostics;

namespace Client_Tracker_MVC.Controllers
{
    public class HomeController : Controller
    {
        MyEntityContext _context = new MyEntityContext("type=embedded;storesdirectory=.\\;storename=Clients");

        public ActionResult Index()
        {
            var clients = _context.Clients;//.OrderBy(c => c.ModifiedDate);

            return View(clients);
        }

        public ActionResult Create()
        {
            var client = new Client();

            return View(client);
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _context.Clients.Add(client);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Edit(string id)
        {
            var client = _context.Clients.FirstOrDefault(d => d.Id.Equals(id));
            return client == null ? View("404") : View(client);
        }


        [HttpPost]
        public ActionResult Edit(Client client)
        {
            if (ModelState.IsValid)
            {
                client.Context = _context;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Delete(string id)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Id.Equals(id));
            return client == null ? View("404") : View(client);
        }

        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var client = _context.Clients.FirstOrDefault(d => d.Id.Equals(id));
            if (client != null)
            {
                _context.DeleteObject(client);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}