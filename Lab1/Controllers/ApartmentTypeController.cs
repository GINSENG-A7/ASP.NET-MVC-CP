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
    public class ApartmentTypeController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: ApartmentType
        public ActionResult Index()
        {
            return View(db.ApartmentTypes.ToList());
        }

        // GET: ApartmentType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentType apartmentType = db.ApartmentTypes.Find(id);
            if (apartmentType == null)
            {
                return HttpNotFound();
            }
            return View(apartmentType);
        }

        // GET: ApartmentType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApartmentType/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type")] ApartmentType apartmentType)
        {
            if (ModelState.IsValid)
            {
                db.ApartmentTypes.Add(apartmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apartmentType);
        }

        // GET: ApartmentType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentType apartmentType = db.ApartmentTypes.Find(id);
            if (apartmentType == null)
            {
                return HttpNotFound();
            }
            return View(apartmentType);
        }

        // POST: ApartmentType/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type")] ApartmentType apartmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apartmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apartmentType);
        }

        // GET: ApartmentType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApartmentType apartmentType = db.ApartmentTypes.Find(id);
            if (apartmentType == null)
            {
                return HttpNotFound();
            }
            return View(apartmentType);
        }

        // POST: ApartmentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApartmentType apartmentType = db.ApartmentTypes.Find(id);
            db.ApartmentTypes.Remove(apartmentType);
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
