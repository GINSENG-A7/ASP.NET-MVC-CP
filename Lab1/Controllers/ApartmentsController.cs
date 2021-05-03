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
    public class ApartmentsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Apartments
        public ActionResult Index()
        {
            return View(db.Apartments.Include(a => a.ApartmentType).ToList());
        }

        // GET: Apartments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apartments apartments = db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == id);
            if (apartments == null)
            {
                return HttpNotFound();
            }
            return View(apartments);
        }

        // GET: Apartments/Create
        public ActionResult Create()
        {
            ApartmentsTypeDataLogistics();

            return View();
        }

        // POST: Apartments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Number,Price,ApartmentTypeId")] Apartments apartments)
        {
            foreach (Apartments n in db.Apartments.ToList())
            {
                //Проверка номера апартаментов на уникальность
                if (apartments.Number == n.Number)
                {
                    ModelState.AddModelError("Number", "Апартаменты с таким номером уже зарегистрированы");
                }
            }

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
            Apartments apartments = db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == id);
            if (apartments == null)
            {
                return HttpNotFound();
            }

            ApartmentsTypeDataLogistics();

            return View(apartments);
        }

        // POST: Apartments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Number,Price,ApartmentTypeId")] Apartments apartments)
        {
            foreach (Apartments n in db.Apartments.AsNoTracking().ToList())
            {
                //Проверка номера апартаментов на уникальность
                if ((apartments.Number == n.Number) && (apartments.Id == n.Id))
                {
                    ModelState.AddModelError("Number", "Апартаменты с таким номером уже зарегистрированы");
                }
            }

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
            Apartments apartments = db.Apartments.Include(a => a.ApartmentType).ToList().Find(x => x.Id == id);
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

        private void ApartmentsTypeDataLogistics()
        {
            List<ApartmentType> listApartmentType = db.ApartmentTypes.ToList();
            List<DataViewApartmentType> viewApartmentType = new List<DataViewApartmentType>();
            foreach (var item in listApartmentType)
            {
                viewApartmentType.Add(new DataViewApartmentType()
                {
                    ApartmentTypeId = item.Id,
                    ApartmentTypeName = item.Type
                });
            }
            ViewBag.ApartmentType = new SelectList(viewApartmentType, "ApartmentTypeId", "ApartmentTypeName");
        }
    }
}
