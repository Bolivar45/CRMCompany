using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMCompany.Models;

namespace CRMCompany.Controllers
{
    public class SellingsController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Sellings
        public ActionResult Index()
        {
            var sellings = db.Sellings.Include(s => s.Currency);
            return View(sellings.ToList());
        }

        // GET: Sellings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingsModel sellingsModel = db.Sellings.Find(id);
            if (sellingsModel == null)
            {
                return HttpNotFound();
            }
            return View(sellingsModel);
        }

        // GET: Sellings/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name");
            return View();
        }

        // POST: Sellings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreId,SellTime,ConterpatryId,Cash,NonCash,Summ,CurrencyId,Comments")] SellingsModel sellingsModel)
        {
            if (ModelState.IsValid)
            {
                db.Sellings.Add(sellingsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", sellingsModel.CurrencyId);
            return View(sellingsModel);
        }

        // GET: Sellings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingsModel sellingsModel = db.Sellings.Find(id);
            if (sellingsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", sellingsModel.CurrencyId);
            return View(sellingsModel);
        }

        // POST: Sellings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreId,SellTime,ConterpatryId,Cash,NonCash,Summ,CurrencyId,Comments")] SellingsModel sellingsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sellingsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", sellingsModel.CurrencyId);
            return View(sellingsModel);
        }

        // GET: Sellings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SellingsModel sellingsModel = db.Sellings.Find(id);
            if (sellingsModel == null)
            {
                return HttpNotFound();
            }
            return View(sellingsModel);
        }

        // POST: Sellings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SellingsModel sellingsModel = db.Sellings.Find(id);
            db.Sellings.Remove(sellingsModel);
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
