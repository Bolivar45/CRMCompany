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
    public class ShipmentsController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: Shipments
        public ActionResult Index()
        {
            var shipments = db.Shipments.Include(s => s.Conterparty).Include(s => s.good).Include(s => s.Warhouse);
            return View(shipments.ToList());
        }

        // GET: Shipments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // GET: Shipments/Create
        public ActionResult Create()
        {
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name");
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name");
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name");
            return View();
        }

        // POST: Shipments/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,ConterpartyId,Prise,Count,Summ,Comments")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Shipments.Add(shipment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", shipment.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", shipment.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", shipment.WarhouseId);
            return View(shipment);
        }

        // GET: Shipments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", shipment.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", shipment.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", shipment.WarhouseId);
            return View(shipment);
        }

        // POST: Shipments/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GoodId,WarhouseId,DateOpen,ConterpartyId,Prise,Count,Summ,Comments")] Shipment shipment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shipment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", shipment.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", shipment.GoodId);
            ViewBag.WarhouseId = new SelectList(db.Warhousies, "Id", "Name", shipment.WarhouseId);
            return View(shipment);
        }

        // GET: Shipments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shipment shipment = db.Shipments.Find(id);
            if (shipment == null)
            {
                return HttpNotFound();
            }
            return View(shipment);
        }

        // POST: Shipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shipment shipment = db.Shipments.Find(id);
            db.Shipments.Remove(shipment);
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
