﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class LivingsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Livings
        public ActionResult Index()
        {
            return View(db.Livings.ToList());
        }

        // GET: Livings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Living living = db.Livings.Find(id);
            if (living == null)
            {
                return HttpNotFound();
            }
            return View(living);
        }

        // GET: Livings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ValueOfGuests,ValueOfKids,Settling,Eviction,NumberOfApartments")] Living living)
        {
            if (ModelState.IsValid)
            {
                db.Livings.Add(living);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(living);
        }

        // GET: Livings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Living living = db.Livings.Find(id);
            if (living == null)
            {
                return HttpNotFound();
            }
            return View(living);
        }

        // POST: Livings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ValueOfGuests,ValueOfKids,Settling,Eviction,NumberOfApartments")] Living living)
        {
            if (ModelState.IsValid)
            {
                db.Entry(living).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(living);
        }

        // GET: Livings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Living living = db.Livings.Find(id);
            if (living == null)
            {
                return HttpNotFound();
            }
            return View(living);
        }

        // POST: Livings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Living living = db.Livings.Find(id);
            db.Livings.Remove(living);
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
    }
}