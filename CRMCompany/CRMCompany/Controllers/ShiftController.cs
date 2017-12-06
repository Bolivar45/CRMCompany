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
    public class ShiftController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Shift
        public ActionResult Index()
        {
            var shiftModels = db.ShiftModels.Include(s => s.Currency).Include(s => s.Entity);
            return View(shiftModels.ToList());
        }

        // GET: Shift/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftModel shiftModel = db.ShiftModels.Find(id);
            if (shiftModel == null)
            {
                return HttpNotFound();
            }
            return View(shiftModel);
        }

        // GET: Shift/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name");
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name");
            return View();
        }

        // POST: Shift/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreId,DateOpen,DateClose,EntityId,SummCash,SummNonCash,Summ,MoneyIn,MoneyOut,CurrencyId,Comments")] ShiftModel shiftModel)
        {
            if (ModelState.IsValid)
            {
                db.ShiftModels.Add(shiftModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", shiftModel.CurrencyId);
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", shiftModel.EntityId);
            return View(shiftModel);
        }

        // GET: Shift/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftModel shiftModel = db.ShiftModels.Find(id);
            if (shiftModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", shiftModel.CurrencyId);
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", shiftModel.EntityId);
            return View(shiftModel);
        }

        // POST: Shift/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreId,DateOpen,DateClose,EntityId,SummCash,SummNonCash,Summ,MoneyIn,MoneyOut,CurrencyId,Comments")] ShiftModel shiftModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shiftModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", shiftModel.CurrencyId);
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", shiftModel.EntityId);
            return View(shiftModel);
        }

        // GET: Shift/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShiftModel shiftModel = db.ShiftModels.Find(id);
            if (shiftModel == null)
            {
                return HttpNotFound();
            }
            return View(shiftModel);
        }

        // POST: Shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShiftModel shiftModel = db.ShiftModels.Find(id);
            db.ShiftModels.Remove(shiftModel);
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
