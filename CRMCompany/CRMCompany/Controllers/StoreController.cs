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
    public class StoreController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Store
        public ActionResult Index()
        {
            var stores = db.Stores.Include(s => s.Entity).Include(s => s.Warhouse);
            return View(stores.ToList());
        }

        // GET: Store/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name");
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name");
            return View();
        }

        // POST: Store/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EntityId,WarhouseId,Addres,Comments")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Stores.Add(storeModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", storeModel.EntityId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", storeModel.WarhouseId);
            return View(storeModel);
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", storeModel.EntityId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", storeModel.WarhouseId);
            return View(storeModel);
        }

        // POST: Store/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EntityId,WarhouseId,Addres,Comments")] StoreModel storeModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(storeModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EntityId = new SelectList(db.Enities, "Id", "Name", storeModel.EntityId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", storeModel.WarhouseId);
            return View(storeModel);
        }

        // GET: Store/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoreModel storeModel = db.Stores.Find(id);
            if (storeModel == null)
            {
                return HttpNotFound();
            }
            return View(storeModel);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoreModel storeModel = db.Stores.Find(id);
            db.Stores.Remove(storeModel);
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
