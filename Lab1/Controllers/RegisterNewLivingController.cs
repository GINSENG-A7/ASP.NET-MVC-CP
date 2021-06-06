using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class RegisterNewLivingController : Controller
    {
        private ContextModel db = new ContextModel();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseDate([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Living living)
        {
            if (ModelState.IsValid)
            {
                ViewBag.LivingId = living.Id;
                ViewBag.Settling = living.Settling;
                ViewBag.Eviction = living.Eviction;
                ViewBag.ValueOfGuests = living.ValueOfGuests;
                ViewBag.ValueOfKids = living.ValueOfKids;
                ViewBag.ClientId = living.ClientId;
                string settlingStr = ConvertDateToString(living.Settling);
                string evictionStr = ConvertDateToString(living.Eviction);
                var requestResultTest = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                //var requestRT = db.Apartments.($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                //DbSqlQuery
                DbSqlQuery<Apartments> apartmentsQuery = db.Apartments.SqlQuery($"SELECT * FROM Apartments b WHERE EXISTS (SELECT a.id FROM Apartments a WHERE b.id = a.id AND a.price > {0} AND a.price < {999999} AND (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id) AND NOT EXISTS(SELECT apartmentsid FROM Bookings WHERE EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))) OR (EXISTS (SELECT apartmentsid FROM Bookings WHERE settling > '{evictionStr}' AND apartmentsid = a.id) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction < '{settlingStr}' AND apartmentsid = a.id))) AND NOT EXISTS(SELECT apartmentsid FROM Livings WHERE EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id)) OR (( EXISTS (SELECT apartmentsid FROM Livings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)) AND ( EXISTS (SELECT apartmentsid FROM Bookings WHERE settling>'{evictionStr}' AND apartmentsid = a.id ) OR ( EXISTS (SELECT apartmentsid FROM Bookings WHERE eviction<'{settlingStr}' AND apartmentsid = a.id)))) OR ( NOT EXISTS (SELECT apartmentsid FROM Livings WHERE apartmentsid = a.id) AND NOT EXISTS (SELECT apartmentsid FROM Bookings WHERE apartmentsid = a.id))))");
                List<Apartments> apartments = new List<Apartments>();
                foreach (Apartments apt in apartmentsQuery.ToList())
                {
                    apartments.Add(db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == apt.Id));
                }
                return View("~/Views/RegisterNewLiving/LivingAvailableApartments.cshtml", apartments);
            }

            return View("~/Views/RegisterNewLiving/LivingDateChooser.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinishTheRegistration(int? ApartmentId, int? LivingId, int? ClientId, DateTime? Settling, DateTime? Eviction, int? ValueOfGuests, int? ValueOfKids)
        {
            Apartments currentApartment = db.Apartments.Include(a => a.ApartmentType).Where(x => x.Id == ApartmentId).First();
            Client currentClient = db.Clients.Include(l => l.Livings).Include(l => l.Livings).Where(x => x.Id == ClientId).First();

            Living currentLiving = new Living();
            currentLiving.Id = (int)LivingId;
            currentLiving.ApartmentsId = ApartmentId;
            currentLiving.ClientId = ClientId;
            currentLiving.Settling = (DateTime)Settling;
            currentLiving.Eviction = (DateTime)Eviction;
            currentLiving.ValueOfGuests = (int)ValueOfGuests;
            currentLiving.ValueOfKids = (int)ValueOfKids;

            if ((currentClient.Bookings.Count + currentClient.Livings.Count) < 6)
            {
                db.Livings.Add(currentLiving);
                db.SaveChanges();
            }
            return View("~/Views/Livings/Index.cshtml");
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