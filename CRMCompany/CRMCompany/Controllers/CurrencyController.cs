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
    public class CurrencyController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Currency
        public ActionResult Index()
        {
            return View(db.Currency.ToList());
        }

        // GET: Currency/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyModel currencyModel = db.Currency.Find(id);
            if (currencyModel == null)
            {
                return HttpNotFound();
            }
            return View(currencyModel);
        }

        // GET: Currency/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Currency/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FullName,Сoefficient")] CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                db.Currency.Add(currencyModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(currencyModel);
        }

        // GET: Currency/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyModel currencyModel = db.Currency.Find(id);
            if (currencyModel == null)
            {
                return HttpNotFound();
            }
            return View(currencyModel);
        }

        // POST: Currency/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FullName,Сoefficient")] CurrencyModel currencyModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(currencyModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(currencyModel);
        }

        // GET: Currency/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurrencyModel currencyModel = db.Currency.Find(id);
            if (currencyModel == null)
            {
                return HttpNotFound();
            }
            return View(currencyModel);
        }

        // POST: Currency/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurrencyModel currencyModel = db.Currency.Find(id);
            db.Currency.Remove(currencyModel);
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
