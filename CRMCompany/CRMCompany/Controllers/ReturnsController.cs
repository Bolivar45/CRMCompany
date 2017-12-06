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
    public class ReturnsController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Returns
        public ActionResult Index()
        {
            var returnsModels = db.ReturnsModels.Include(r => r.Currency);
            return View(returnsModels.ToList());
        }

        // GET: Returns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsModel returnsModel = db.ReturnsModels.Find(id);
            if (returnsModel == null)
            {
                return HttpNotFound();
            }
            return View(returnsModel);
        }

        // GET: Returns/Create
        public ActionResult Create()
        {
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name");
            return View();
        }

        // POST: Returns/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StoreId,ConterpatryId,Cash,NonCash,Summ,CurrencyId,Comments")] ReturnsModel returnsModel)
        {
            if (ModelState.IsValid)
            {
                db.ReturnsModels.Add(returnsModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", returnsModel.CurrencyId);
            return View(returnsModel);
        }

        // GET: Returns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsModel returnsModel = db.ReturnsModels.Find(id);
            if (returnsModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", returnsModel.CurrencyId);
            return View(returnsModel);
        }

        // POST: Returns/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StoreId,ConterpatryId,Cash,NonCash,Summ,CurrencyId,Comments")] ReturnsModel returnsModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnsModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CurrencyId = new SelectList(db.Currency, "Id", "Name", returnsModel.CurrencyId);
            return View(returnsModel);
        }

        // GET: Returns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnsModel returnsModel = db.ReturnsModels.Find(id);
            if (returnsModel == null)
            {
                return HttpNotFound();
            }
            return View(returnsModel);
        }

        // POST: Returns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnsModel returnsModel = db.ReturnsModels.Find(id);
            db.ReturnsModels.Remove(returnsModel);
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
