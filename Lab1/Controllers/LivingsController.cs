using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab1.Models;
using Lab1.Models.DataViewModels;
using OfficeOpenXml;

namespace Lab1.Controllers
{
    public class LivingsController : Controller
    {
        private ContextModel db = new ContextModel();

        // GET: Livings
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return View(db.Livings.Include(a => a.Apartments).Include(c => c.Client).ToList());
            }
            else
            {
                return View(db.Livings.Include(a => a.Apartments).Include(c => c.Client).Where(x => x.Client.Id == id).ToList());
            }
        }

        // GET: Livings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Living living = db.Livings.Include(a => a.Apartments).Include(c => c.Client).ToList().Find(x => x.Id == id);
            if (living == null)
            {
                return HttpNotFound();
            }
            return View(living);
        }

        ////Удалить, т.к. добавление проживаний и броней происходит через клиента
        //// GET: Livings/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Livings/Create
        //// Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        //// сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,ValueOfGuests,ValueOfKids,Settling,Eviction,NumberOfApartments")] Living living)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Livings.Add(living);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(living);
        //}

        // GET: Livings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Living living = db.Livings.Include(a => a.Apartments).ToList().Find(x => x.Id == id);
            if (living == null)
            {
                return HttpNotFound();
            }

            ApartmentsDataLogistics();

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

        private void ApartmentsDataLogistics()
        {
            List<Apartments> listApartments = db.Apartments.ToList();
            List<DataViewApartment> viewApartments = new List<DataViewApartment>();
            foreach (var item in listApartments)
            {
                viewApartments.Add(new DataViewApartment()
                {
                    ApartmentsId = item.Id,
                    ApartmentsNumber = item.Number
                });
            }
            ViewBag.Apartments = new SelectList(viewApartments, "ApartmentsId", "ApartmentsNumber");
        }

        public ActionResult ShowAdditionalServices(int id)
        {
            Living living = db.Livings.Include(a => a.Apartments).Include(c => c.Client).Include(s => s.AditionServices).ToList().Find(x => x.Id == id);
            if (living == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Index", "AditionServices", new { id = living.Id });
        }

        public FileResult ExelCreate()
        {
            // Путь к файлу с шаблоном
            string file_path_template = Server.MapPath("~/Content/Reports/Scheme.xlsx");

            FileInfo fi = new FileInfo(file_path_template);
            //Путь к файлу с результатом
            string file_path = Server.MapPath("~/Content/Reports/Report.xlsx");

            FileInfo fi_report = new FileInfo(file_path);
            //будем использовть библитотеку не для коммерческого использования

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            //открываем файл с шаблоном 
            using (ExcelPackage excelPackage = new ExcelPackage(fi))
            {
                //устанавливаем поля документа
                excelPackage.Workbook.Properties.Author = "Директор";
                excelPackage.Workbook.Properties.Title = "Список клиентов компанни";
                excelPackage.Workbook.Properties.Subject = "Пользователи системы";
                excelPackage.Workbook.Properties.Created = DateTime.Now;

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Лист1"];

                int startLine = 3;

                var livingsList = db.Livings.Include(c => c.Client).Include(a => a.Apartments).Include(s => s.AditionServices).Where(x => x.Settling.Month == DateTime.Now.Month && x.Settling.Month == DateTime.Now.Month).ToList();

                foreach (var item in livingsList)
                {
                    var client = db.Clients.First(x => x.Id == item.ClientId);
                    var apartment = db.Apartments.First(x => x.Id == item.ApartmentsId);
                    var aditionServices = db.AditionServices.Where(x => x.LivingsId == item.Id);

                    string actualityRow = "Завершено";
                    if(item.Eviction >= DateTime.Now)
                    {
                        actualityRow = "Активно";
                    }

                    int resultPrice = apartment.Price * (item.ValueOfGuests + item.ValueOfKids);
                    int servicesPricesSumm = 0;
                    foreach(var serv in aditionServices)
                    {
                        servicesPricesSumm += serv.Price;
                    }

                    worksheet.Cells[startLine, 1].Value = client.Name;
                    worksheet.Cells[startLine, 2].Value = client.Surname;
                    worksheet.Cells[startLine, 3].Value = client.Patronymic;
                    worksheet.Cells[startLine, 4].Value = item.Settling.ToString();
                    worksheet.Cells[startLine, 5].Value = item.Eviction.ToString();
                    worksheet.Cells[startLine, 6].Value = actualityRow;
                    worksheet.Cells[startLine, 7].Value = resultPrice;
                    worksheet.Cells[startLine, 8].Value = servicesPricesSumm;

                    startLine++;
                }

                excelPackage.SaveAs(fi_report);
            }

            string file_type = "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet";
            string file_name = "Scheme.xlsx";

            return File(file_path, file_type, file_name);
        }
    }
}
