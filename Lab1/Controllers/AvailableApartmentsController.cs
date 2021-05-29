using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class AvailableApartmentsController : Controller
    {
        private ContextModel db = new ContextModel();

        public ActionResult AvailableApartments(int? id, DateTime? settling, DateTime? eviction, int? vog, int? vok)
        {
            ViewBag.ClientId = id;
            string settlingStr = ConvertDateToString(settling);
            string evictionStr = ConvertDateToString(eviction);
            var requestResultTest = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
            //var requestRT = db.Apartments.($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
            //DbSqlQuery
            DbSqlQuery<Apartments> apartmentsQuery = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
            List<Apartments> apartments = new List<Apartments>();
            foreach (Apartments apt in apartmentsQuery.ToList())
            {
                apartments.Add(db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == apt.Id));
            }

            return View("AvailableApartments", apartments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinishTheRegistration([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Booking booking)
        {
            return View(booking);
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