using System;
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
    public class ApartmentsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Apartments
        public ActionResult Index()
        {
            return View(db.Apartments.ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Price")] Apartments apartments)
        {
            if (ModelState.IsValid)
            {
                db.Apartments.Add(apartments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartments);
        }

        // GET: Apartments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // POST: Apartments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Price")] Apartments apartments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartments);
        }

        // GET: Apartments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Find(id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // POST: Apartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Apartments apartments = db.Apartments.Find(id);
            db.Apartments.Remove(apartments);
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
