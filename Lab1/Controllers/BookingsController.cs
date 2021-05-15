using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;
using Lab1.Models.DataViewModels;

namespace Lab1.Controllers
{
    public class BookingsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Bookings
        public ActionResult Index()
        {
            return View(db.Bookings.Include(a => a.Apartments).ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Include(a => a.Apartments).ToList().Find(x => x.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        public ActionResult AvailableApartments(int? id, DateTime? settling, DateTime? eviction, int? vog, int? vok) 
        {
            ViewBag.ClientId = id;
            var requestResult = db.Database.SqlQuery<Apartments>($"SELECT a.number, a.\"type\", a.price FROM Apartments a WHERE a.price > {0} AND a.price < {999999} AND ((a.number IN (SELECT number FROM Living WHERE eviction < '{settling}') AND NOT EXISTS(SELECT number FROM Booking WHERE a.number IN (SELECT number FROM Booking))) OR (a.number in (SELECT number FROM Booking WHERE settling > '{eviction}') OR (a.number in (SELECT number FROM Booking WHERE eviction < '{settling}'))) AND NOT EXISTS(SELECT number FROM Living WHERE a.number IN (SELECT number FROM Living)) OR ((a.number in (SELECT number FROM Living WHERE eviction<'{settling}')) AND (a.number in (SELECT number FROM Booking WHERE settling>'{eviction}') OR (a.number in (SELECT number FROM Booking WHERE eviction<'{settling}')))) OR (a.number NOT IN (SELECT number FROM Living) AND a.number NOT IN (SELECT number FROM Booking)))");
            return View(db.Apartments.Include(a => a.ApartmentType).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AvailableApartments([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Booking booking)
        {
            return View(booking);
        }
        // GET: Bookings/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult BookingDateChooser(int? id)
        {
            ViewBag.ClientId = id;
            return View("BookingDateChooser");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BookingDateChooser([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AvailableApartments", new { id = booking.ClientId, settling = booking.Settling, eviction = booking.Eviction, vog = booking.ValueOfGuests, vok = booking.ValueOfKids });
            }

            return View(booking);
        }
        public ActionResult Create(int? id)
        {
            ApartmentsDataLogistics();
            ViewBag.ClientId = id;
            return View();
        }
        // POST: Bookings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValueOfGuests,ValueOfKids,Settling,Eviction,ClientId,ApartmentsId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Include(a => a.Apartments).ToList().Find(x => x.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }

            ApartmentsDataLogistics();

            return View(booking);
        }

        // POST: Bookings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValueOfGuests,ValueOfKids,Settling,Eviction,NumberOfApartments")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Include(a => a.Apartments).ToList().Find(x => x.Id == id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

        private void ApartmentsDataLogistics()
        {
            List<Apartments> listApartments = db.Apartments.ToList();
            List<DataViewApartment> viewApartments = new List<DataViewApartment>();
            foreach (var item in listApartments)
            {
                viewApartments.Add(new DataViewApartment()
                {
                    ApartmentsId = item.Id,
                    ApartmentsNumber = item.Number
                });
            }
            ViewBag.Apartments = new SelectList(viewApartments, "ApartmentsId", "ApartmentsNumber");
        }
        private void ClientsDataLogistics()
        {
            List<Client> listClients = db.Clients.ToList();
            List<DataViewClient> viewClient = new List<DataViewClient>();
            foreach (var item in listClients)
            {
                viewClient.Add(new DataViewClient()
                {
                    ClientId = item.Id,
                    ClientFIO = item.Surname + " " + item.Name + " " + item.Patronymic
                });
            }
            ViewBag.Client = new SelectList(viewClient, "ClientId", "ClientFIO");
        }
    }
}
