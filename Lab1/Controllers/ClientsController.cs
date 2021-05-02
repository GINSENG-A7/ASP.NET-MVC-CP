using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class ClientsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Clients
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: Clients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Surname,Name,Patronymic,PassportNumber,PassportSeries,Birgthday,Telephone")] Client client)
        {
            IEnumerable<Client> listOfClients = db.Clients;
            foreach (Client c in listOfClients)
            {
                //Проверка пасспортных данных на уникальность
                if (client.PassportNumber == c.PassportNumber && client.PassportSeries == c.PassportSeries)
                {
                    ModelState.AddModelError("PassportSeries", "Клиент с такими серией или номером паспорта уже зарегистрирован");
                }

                //Проверка телефона на уникальность
                if (client.Telephone == c.Telephone)
                {
                    ModelState.AddModelError("Telephone", "Клиент с таким телефоном уже зарегистрирован");
                }
            }

            if (ModelState.IsValid)
            {
                db.Clients.Add(client);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Surname,Name,Patronymic,PassportNumber,PassportSeries,Birgthday,Telephone")] Client client)
        {
            foreach (Client c in db.Clients.AsNoTracking().ToList())
            {
                //Проверка пасспортных данных на уникальность
                if ((client.PassportNumber == c.PassportNumber && client.PassportSeries == c.PassportSeries) && (client.Id != c.Id))
                {
                    ModelState.AddModelError("PassportSeries", "Клиент с такими серией или номером паспорта уже зарегистрирован");
                }

                //Проверка телефона на уникальность
                if ((client.Telephone == c.Telephone) && (client.Id != c.Id))
                {
                    ModelState.AddModelError("Telephone", "Клиент с таким телефоном уже зарегистрирован");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified; //Тут ломается
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult SearchWithValues(string searchableName, string searchableSurname, string searchablePatronymic, string searchableTelephone)
        {    
            IEnumerable<Client> listOfClients  = db.Clients;
            var clients = from linqC in listOfClients where linqC.Name == searchableName && linqC.Surname == searchableSurname && linqC.Patronymic == searchablePatronymic && linqC.Telephone == searchableTelephone select linqC;
            return View(clients);
        }
    }
}
