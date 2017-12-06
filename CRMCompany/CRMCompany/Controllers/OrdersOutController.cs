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
    public class OrdersOutController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: OrdersOut
        public ActionResult Index()
        {
            var ordersOutModels = db.OrdersOutModels.Include(o => o.Conterparty).Include(o => o.good);
            return View(ordersOutModels.ToList());
        }

        // GET: OrdersOut/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOutModel ordersOutModel = db.OrdersOutModels.Find(id);
            if (ordersOutModel == null)
            {
                return HttpNotFound();
            }
            return View(ordersOutModel);
        }

        // GET: OrdersOut/Create
        public ActionResult Create()
        {
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name");
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name");
            return View();
        }

        // POST: OrdersOut/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GoodId,DateOpen,ConterpartyId,Prise,Count,Summ")] OrdersOutModel ordersOutModel)
        {
            if (ModelState.IsValid)
            {
                db.OrdersOutModels.Add(ordersOutModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", ordersOutModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", ordersOutModel.GoodId);
            return View(ordersOutModel);
        }

        // GET: OrdersOut/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOutModel ordersOutModel = db.OrdersOutModels.Find(id);
            if (ordersOutModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", ordersOutModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", ordersOutModel.GoodId);
            return View(ordersOutModel);
        }

        // POST: OrdersOut/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GoodId,DateOpen,ConterpartyId,Prise,Count,Summ")] OrdersOutModel ordersOutModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersOutModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", ordersOutModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", ordersOutModel.GoodId);
            return View(ordersOutModel);
        }

        // GET: OrdersOut/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersOutModel ordersOutModel = db.OrdersOutModels.Find(id);
            if (ordersOutModel == null)
            {
                return HttpNotFound();
            }
            return View(ordersOutModel);
        }

        // POST: OrdersOut/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersOutModel ordersOutModel = db.OrdersOutModels.Find(id);
            db.OrdersOutModels.Remove(ordersOutModel);
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
