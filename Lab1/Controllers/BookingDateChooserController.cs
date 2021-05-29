using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class BookingDateChooserController : Controller
    {
        private ContextModel db = new ContextModel();

        public ActionResult BookingDateChooser(int? id)
        {
            ViewBag.ClientId = id;
            return View("~/Views/BookingDateChooser/BookingDateChooser.cshtml");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseDate([Bind(Include = "Settling,Eviction,ValueOfGuests,ValueOfKids,ClientId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("AvailableApartments", new { id = booking.ClientId, settling = booking.Settling, eviction = booking.Eviction, vog = booking.ValueOfGuests, vok = booking.ValueOfKids });
            }

            return View(booking);
        }
    }
}