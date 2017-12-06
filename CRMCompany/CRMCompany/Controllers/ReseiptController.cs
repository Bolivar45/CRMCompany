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
    public class ReseiptController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Reseipt
        public ActionResult Index()
        {
            var reseiptModels = db.ReseiptModels.Include(r => r.Conterparty).Include(r => r.good).Include(r => r.Warhouse);
            return View(reseiptModels.ToList());
        }

        // GET: Reseipt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReseiptModel reseiptModel = db.ReseiptModels.Find(id);
            if (reseiptModel == null)
            {
                return HttpNotFound();
            }
            return View(reseiptModel);
        }

        // GET: Reseipt/Create
        public ActionResult Create()
        {
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name");
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name");
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name");
            return View();
        }

        // POST: Reseipt/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,ConterpartyId,Prise,Count,Summ,Comments")] ReseiptModel reseiptModel)
        {
            if (ModelState.IsValid)
            {
                db.ReseiptModels.Add(reseiptModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", reseiptModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", reseiptModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", reseiptModel.WarhouseId);
            return View(reseiptModel);
        }

        // GET: Reseipt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReseiptModel reseiptModel = db.ReseiptModels.Find(id);
            if (reseiptModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", reseiptModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", reseiptModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", reseiptModel.WarhouseId);
            return View(reseiptModel);
        }

        // POST: Reseipt/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,ConterpartyId,Prise,Count,Summ,Comments")] ReseiptModel reseiptModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reseiptModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", reseiptModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", reseiptModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", reseiptModel.WarhouseId);
            return View(reseiptModel);
        }

        // GET: Reseipt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReseiptModel reseiptModel = db.ReseiptModels.Find(id);
            if (reseiptModel == null)
            {
                return HttpNotFound();
            }
            return View(reseiptModel);
        }

        // POST: Reseipt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReseiptModel reseiptModel = db.ReseiptModels.Find(id);
            db.ReseiptModels.Remove(reseiptModel);
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
