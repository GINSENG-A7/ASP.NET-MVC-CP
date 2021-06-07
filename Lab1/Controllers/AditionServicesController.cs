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
    public class AditionServicesController : Controller
    {
        private ContextModel db = new ContextModel();
        public static bool isEnabledCreateNew = false;

        // GET: AditionServices
        public ActionResult Index(int? id)
        {
            if(id == null)
            {
                isEnabledCreateNew = false;
                ViewBag.isEnabledCreateNew = isEnabledCreateNew;
                return View(db.AditionServices.Include(a => a.ServiceTypes).ToList());
            }
            else
            {
                ViewBag.LivingId = id;
                isEnabledCreateNew = true;
                ViewBag.isEnabledCreateNew = isEnabledCreateNew;
                return View(db.AditionServices.Include(a => a.ServiceTypes).Where(x => x.Living.Id == id).ToList());
            }
        }

        // GET: AditionServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AditionServices aditionServices = db.AditionServices.Include(a => a.ServiceTypes).ToList().Find(x => x.Id == id);
            if (aditionServices == null)
            {
                return HttpNotFound();
            }
            return View(aditionServices);
        }

        // GET: AditionServices/Create
        public ActionResult Create(int? LivingId)
        {
            ViewBag.LivingId = LivingId;
            ServiceTypesDataLogistics();
            return View();
        }

        // POST: AditionServices/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,DateOfService,ServicesTypeId")] AditionServices aditionServices, int? LivingId)
        {
            aditionServices.LivingsId = LivingId;
            Living living = db.Livings.Where(x => x.Id == LivingId).First();
            //Проверка корректности даты оказания дополнительных услуг 
            if (aditionServices.DateOfService < living.Settling)
            {
                ModelState.AddModelError("Number", "Дата оказания услуги не может быть меньше даты заезда");
            }
            if (aditionServices.DateOfService > living.Eviction)
            {
                ModelState.AddModelError("Number", "Дата оказания услуги не может быть больше даты выезда");
            }

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
            AditionServices aditionServices = db.AditionServices.Include(a => a.ServiceTypes).ToList().Find(x => x.Id == id);
            if (aditionServices == null)
            {
                return HttpNotFound();
            }

            ServiceTypesDataLogistics();

            return View(aditionServices);
        }

        // POST: AditionServices/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,DateOfService,ServicesTypeId")] AditionServices aditionServices)
        {
            //Проверка корректности даты оказания дополнительных услуг 
            if (aditionServices.DateOfService < aditionServices.Living.Settling)
            {
                ModelState.AddModelError("Number", "Дата оказания услуги не может быть меньше даты заезда");
            }
            if (aditionServices.DateOfService > aditionServices.Living.Eviction)
            {
                ModelState.AddModelError("Number", "Дата оказания услуги не может быть больше даты выезда");
            }

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
            AditionServices aditionServices = db.AditionServices.Include(a => a.ServiceTypes).ToList().Find(x => x.Id == id);
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

        private void ServiceTypesDataLogistics()
        {
            List<ServiceType> listServiceType = db.ServiceTypes.ToList();
            List<DataViewServiceType> viewServiceType = new List<DataViewServiceType>();
            foreach (var item in listServiceType)
            {
                viewServiceType.Add(new DataViewServiceType()
                {
                    ServiceTypeId = item.Id,
                    ServiceTypeName = item.Type
                });
            }
            ViewBag.ServiceTypes = new SelectList(viewServiceType, "ServiceTypeId", "ServiceTypeName");
        }
    }
}
