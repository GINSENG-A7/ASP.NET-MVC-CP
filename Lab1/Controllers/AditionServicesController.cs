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
    public class AditionServicesController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: AditionServices
        public ActionResult Index()
        {
            return View(db.AditionServices.ToList());
        }

        // GET: AditionServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AditionServices aditionServices = db.AditionServices.Find(id);
            if (aditionServices == null)
            {
                return HttpNotFound();
            }
            return View(aditionServices);
        }

        // GET: AditionServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AditionServices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price")] AditionServices aditionServices)
        {
            if (ModelState.IsValid)
            {
                db.AditionServices.Add(aditionServices);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aditionServices);
        }

        // GET: AditionServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AditionServices aditionServices = db.AditionServices.Find(id);
            if (aditionServices == null)
            {
                return HttpNotFound();
            }
            return View(aditionServices);
        }

        // POST: AditionServices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price")] AditionServices aditionServices)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aditionServices).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aditionServices);
        }

        // GET: AditionServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AditionServices aditionServices = db.AditionServices.Find(id);
            if (aditionServices == null)
            {
                return HttpNotFound();
            }
            return View(aditionServices);
        }

        // POST: AditionServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AditionServices aditionServices = db.AditionServices.Find(id);
            db.AditionServices.Remove(aditionServices);
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
