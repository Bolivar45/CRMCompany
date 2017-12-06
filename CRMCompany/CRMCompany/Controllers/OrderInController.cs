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
    public class OrderInController : Controller
    {
        private ContextDB db = new ContextDB();

        // GET: OrderIn
        public ActionResult Index()
        {
            var orderInModels = db.OrderInModels.Include(o => o.Conterparty).Include(o => o.good);
            return View(orderInModels.ToList());
        }

        // GET: OrderIn/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInModel orderInModel = db.OrderInModels.Find(id);
            if (orderInModel == null)
            {
                return HttpNotFound();
            }
            return View(orderInModel);
        }

        // GET: OrderIn/Create
        public ActionResult Create()
        {
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name");
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name");
            return View();
        }

        // POST: OrderIn/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GoodId,DateOpen,ConterpartyId,Prise,Count,Summ")] OrderInModel orderInModel)
        {
            if (ModelState.IsValid)
            {
                db.OrderInModels.Add(orderInModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", orderInModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", orderInModel.GoodId);
            return View(orderInModel);
        }

        // GET: OrderIn/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInModel orderInModel = db.OrderInModels.Find(id);
            if (orderInModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", orderInModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", orderInModel.GoodId);
            return View(orderInModel);
        }

        // POST: OrderIn/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,GoodId,DateOpen,ConterpartyId,Prise,Count,Summ")] OrderInModel orderInModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderInModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ConterpartyId = new SelectList(db.Conterparties, "Id", "Name", orderInModel.ConterpartyId);
            ViewBag.GoodId = new SelectList(db.GoodModels, "Id", "Name", orderInModel.GoodId);
            return View(orderInModel);
        }

        // GET: OrderIn/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderInModel orderInModel = db.OrderInModels.Find(id);
            if (orderInModel == null)
            {
                return HttpNotFound();
            }
            return View(orderInModel);
        }

        // POST: OrderIn/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderInModel orderInModel = db.OrderInModels.Find(id);
            db.OrderInModels.Remove(orderInModel);
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
