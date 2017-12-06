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
    public class LossController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Loss
        public ActionResult Index()
        {
            var lossModels = db.LossModels.Include(l => l.good).Include(l => l.Warhouse);
            return View(lossModels.ToList());
        }

        // GET: Loss/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LossModel lossModel = db.LossModels.Find(id);
            if (lossModel == null)
            {
                return HttpNotFound();
            }
            return View(lossModel);
        }

        // GET: Loss/Create
        public ActionResult Create()
        {
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name");
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name");
            return View();
        }

        // POST: Loss/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,Count,Comments")] LossModel lossModel)
        {
            if (ModelState.IsValid)
            {
                db.LossModels.Add(lossModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", lossModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", lossModel.WarhouseId);
            return View(lossModel);
        }

        // GET: Loss/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LossModel lossModel = db.LossModels.Find(id);
            if (lossModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", lossModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", lossModel.WarhouseId);
            return View(lossModel);
        }

        // POST: Loss/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,Count,Comments")] LossModel lossModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lossModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", lossModel.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", lossModel.WarhouseId);
            return View(lossModel);
        }

        // GET: Loss/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LossModel lossModel = db.LossModels.Find(id);
            if (lossModel == null)
            {
                return HttpNotFound();
            }
            return View(lossModel);
        }

        // POST: Loss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LossModel lossModel = db.LossModels.Find(id);
            db.LossModels.Remove(lossModel);
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
