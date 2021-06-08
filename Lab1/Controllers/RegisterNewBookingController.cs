using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class RegisterNewBookingController : Controller
    {
        private ContextModel db = new ContextModel();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseDate([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                //return RedirectToAction("AvailableApartments", new { id = booking.ClientId, settling = booking.Settling, eviction = booking.Eviction, vog = booking.ValueOfGuests, vok = booking.ValueOfKids });
                ViewBag.BookingId = booking.Id;
                ViewBag.Settling = booking.Settling;
                ViewBag.Eviction = booking.Eviction;
                ViewBag.ValueOfGuests = booking.ValueOfGuests;
                ViewBag.ValueOfKids = booking.ValueOfKids;
                ViewBag.ClientId = booking.ClientId;
                string settlingStr = ConvertDateToString(booking.Settling);
                string evictionStr = ConvertDateToString(booking.Eviction);
                var requestResultTest = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                //var requestRT = db.Apartments.($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                //DbSqlQuery
                DbSqlQuery<Apartments> apartmentsQuery = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                List<Apartments> apartments = new List<Apartments>();
                foreach (Apartments apt in apartmentsQuery.ToList())
                {
                    apartments.Add(db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == apt.Id));
                }
                return View("~/Views/RegisterNewBooking/BookingAvailableApartments.cshtml", apartments);
            }

            return View("~/Views/RegisterNewBooking/BookingDateChooser.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinishTheRegistration(int? ApartmentId, int? BookingId, int? ClientId, DateTime? Settling, DateTime? Eviction, int? ValueOfGuests, int? ValueOfKids)
        {
            Apartments currentApartment = db.Apartments.Include(a => a.ApartmentType).Where(x => x.Id == ApartmentId).First(); 
            Client currentClient = db.Clients.Include(l => l.Livings).Include(b => b.Bookings).Where(x => x.Id == ClientId).First();

            Booking currentBooking = new Booking();
            currentBooking.Id = (int)BookingId;
            currentBooking.ApartmentsId = ApartmentId;
            currentBooking.ClientId = ClientId;
            currentBooking.Settling = (DateTime)Settling;
            currentBooking.Eviction = (DateTime)Eviction;
            currentBooking.ValueOfGuests = (int)ValueOfGuests;
            currentBooking.ValueOfKids = (int)ValueOfKids;

            if ((currentClient.Bookings.Count + currentClient.Livings.Count) < 6)
            {
                db.Bookings.Add(currentBooking);
                db.SaveChanges();
            }
            //return View("~/Views/Bookings/Index.cshtml");
            return RedirectToAction("Index", "Bookings", new { });
        }

        public String ConvertDateToString(DateTime? dt)
        {
            if (dt != null)
            {
                string processingStr = dt.ToString();
                processingStr = processingStr.Substring(0, 10);
                string day = processingStr.Substring(0, 2);
                string month = processingStr.Substring(3, 2);
                string year = processingStr.Substring(6, 4);
                return year + "-" + month + "-" + day;
            }
            return ConvertDateToString(DateTime.Today);
        }
    }
}